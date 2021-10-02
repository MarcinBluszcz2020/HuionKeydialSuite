using HidLibrary;
using System;
using System.Linq;

namespace HKS.Core.Huion
{
    public class HuionKD100 : IDisposable
    {
        private const byte KeyReportFirstByte = 224;
        private const byte DialReportFirstByte = 241;

        private HidDevice _device;

        public bool Attached
        {
            get;
            private set;
        }

        public event EventHandler<HuionKeyReport> KeyReport;
        public event EventHandler DialClockwiseTick;
        public event EventHandler DialCounterClockwiseTick;

        public HuionKD100()
        {
            _device = HidDevices.Enumerate((int)DriverConst.HuionVendorId).FirstOrDefault();

            if (_device == null)
            {
                throw new Exception("Huion KD 100 device not found");
            }

            _device.OpenDevice();

            _device.Inserted += DeviceAttachedHandler;
            _device.Removed += DeviceRemovedHandler;

            _device.MonitorDeviceEvents = true;

            _device.ReadReport(OnReport);
        }

        private void DeviceAttachedHandler()
        {
            Attached = true;
            _device.ReadReport(OnReport);
        }

        private void DeviceRemovedHandler()
        {
            Attached = false;
        }

        private void OnReport(HidReport report)
        {
            _device.ReadReport(OnReport);

            if (!Attached)
            {
                return;
            }

            if (report.ReadStatus == HidDeviceData.ReadStatus.Success)
            {
                if (IsKeyReport(report.Data))
                {
                    HandleKeyReport(report);
                }

                if (IsDialReport(report.Data))
                {
                    HandleDialReport(report.Data);
                }
            }
        }

        private void HandleKeyReport(HidReport report)
        {
            var huionReport = PrepareKeyReport(report.Data);

            KeyReport?.Invoke(this, huionReport);
        }

        private void HandleDialReport(byte[] rawData)
        {
            var byte_4 = rawData[4];

            var clockwise = (byte_4 & (1 << 0)) > 0;
            var counterClockwise = (byte_4 & (1 << 1)) > 0;

            if (clockwise)
            {
                DialClockwiseTick?.Invoke(this, EventArgs.Empty);
            }

            if (counterClockwise)
            {
                DialCounterClockwiseTick?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool IsKeyReport(byte[] rawData)
        {
            var reportTypeByte = rawData[0];

            return reportTypeByte == KeyReportFirstByte;
        }

        private bool IsDialReport(byte[] rawData)
        {
            var reportTypeByte = rawData[0];

            return reportTypeByte == DialReportFirstByte;
        }

        private HuionKeyReport PrepareKeyReport(byte[] rawData)
        {
            bool a0 = false, a1 = false, a2 = false, a3 = false, a4 = false, a5 = false, a6 = false, a7 = false;
            bool b0 = false, b1 = false, b2 = false, b3 = false, b4 = false, b5 = false, b6 = false, b7 = false;
            bool c0 = false, c1 = false, c2 = false;

            var byte_3 = rawData[3];

            a0 = (byte_3 & (1 << 0)) > 0;
            a1 = (byte_3 & (1 << 1)) > 0;
            a2 = (byte_3 & (1 << 2)) > 0;
            a3 = (byte_3 & (1 << 3)) > 0;
            a4 = (byte_3 & (1 << 4)) > 0;
            a5 = (byte_3 & (1 << 5)) > 0;
            a6 = (byte_3 & (1 << 6)) > 0;
            a7 = (byte_3 & (1 << 7)) > 0;

            var byte_4 = rawData[4];

            b0 = (byte_4 & (1 << 0)) > 0;
            b1 = (byte_4 & (1 << 1)) > 0;
            b2 = (byte_4 & (1 << 2)) > 0;
            b3 = (byte_4 & (1 << 3)) > 0;
            b4 = (byte_4 & (1 << 4)) > 0;
            b5 = (byte_4 & (1 << 5)) > 0;
            b6 = (byte_4 & (1 << 6)) > 0;
            b7 = (byte_4 & (1 << 7)) > 0;

            var byte_5 = rawData[5];

            c0 = (byte_5 & (1 << 0)) > 0;
            c1 = (byte_5 & (1 << 1)) > 0;
            c2 = (byte_5 & (1 << 2)) > 0;

            return new HuionKeyReport(a0, a1, a2, a3, a4, a5, a6, a7, b0, b1, b2, b3, b4, b5, b6, b7, c0, c1, c2);
        }

        public void Dispose()
        {
            _device?.Dispose();
        }
    }
}
