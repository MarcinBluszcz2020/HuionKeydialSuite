using HidLibrary;
using System;

namespace HKS.Core
{
    public class RoboustDevice
    {
        private readonly DeviceWaiterTask _deviceWaiterTask;

        public event EventHandler<HidReport> ReportReceived;

        private bool _attached;

        public RoboustDevice(Func<HidDevice> deviceAccessor)
        {
            _deviceWaiterTask = new DeviceWaiterTask(deviceAccessor, TimeSpan.FromSeconds(2), DeviceFound);
            _deviceWaiterTask.WaitForDevice();
        }

        private void DeviceFound(HidDevice device)
        {
            device.OpenDevice();

            device.Inserted += DeviceAttachedHandler;
            device.Removed += () => DeviceRemovedHandler(device);

            device.MonitorDeviceEvents = true;

            device.ReadReport(r => OnReport(r, device));
        }

        private void DeviceAttachedHandler()
        {
            _attached = true;
        }

        private void DeviceRemovedHandler(HidDevice device)
        {
            _attached = false;

            _deviceWaiterTask.WaitForDevice();
        }

        private void OnReport(HidReport report, HidDevice device)
        {
            if (!_attached)
            {
                return;
            }

            device.ReadReport(r => OnReport(r, device));

            if (report.ReadStatus == HidDeviceData.ReadStatus.Success)
            {
                ReportReceived?.Invoke(this, report);
            }
        }
    }
}
