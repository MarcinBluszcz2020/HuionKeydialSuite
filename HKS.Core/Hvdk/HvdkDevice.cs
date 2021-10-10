using HidLibrary;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace HKS.Core.Hvdk
{
    public class HvdkDevice
    {
        private HidDevice _device;

        public bool Attached
        {
            get;
            private set;
        }

        public HvdkDevice()
        {
            _device = HidDevices.Enumerate((int)DriverConst.TetherscriptVendorID, (int)DriverConst.TetherscriptKeyboardProductID).FirstOrDefault();

            if (_device == null)
            {
                throw new Exception("Hvdk device not found");
            }

            _device.OpenDevice();

            _device.Inserted += DeviceAttachedHandler;
            _device.Removed += DeviceRemovedHandler;

            _device.MonitorDeviceEvents = true;
        }

        private void DeviceAttachedHandler()
        {
            Attached = true;
        }

        private void DeviceRemovedHandler()
        {
            Attached = false;
        }

        public void SendEmpty()
        {
            Send(0, 0, 0, 0, 0, 0, 0);
        }

        public void Send(Byte Modifier, Byte Key0, Byte Key1, Byte Key2, Byte Key3, Byte Key4, Byte Key5)
        {
            SetFeatureKeyboard KeyboardData = new SetFeatureKeyboard();
            KeyboardData.ReportID = 1;
            KeyboardData.CommandCode = 2;
            KeyboardData.Timeout = 1000;
            KeyboardData.Modifier = Modifier;
            KeyboardData.Padding = 0;
            KeyboardData.Key0 = Key0;
            KeyboardData.Key1 = Key1;
            KeyboardData.Key2 = Key2;
            KeyboardData.Key3 = Key3;
            KeyboardData.Key4 = Key4;
            KeyboardData.Key5 = Key5;

            var bytesData = GetBytesSFJ(KeyboardData);

            _device.SendData(bytesData, Marshal.SizeOf(KeyboardData));
        }

        private byte[] GetBytesSFJ(SetFeatureKeyboard sfj)
        {
            var size = Marshal.SizeOf(sfj);

            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(sfj, ptr, false);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}
