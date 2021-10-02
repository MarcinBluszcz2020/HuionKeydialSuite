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
            Console.WriteLine("HvdkDevice attached.");
        }

        private void DeviceRemovedHandler()
        {
            Attached = false;
            Console.WriteLine("HvdkDevice removed.");
        }

        //public void SendCtor()
        //{
        //    byte c = _keyboardUtils.GetKeyKeyCode("c");
        //    byte t = _keyboardUtils.GetKeyKeyCode("t");
        //    byte o = _keyboardUtils.GetKeyKeyCode("o");
        //    byte r = _keyboardUtils.GetKeyKeyCode("r");
        //    byte tab = _keyboardUtils.GetKeyKeyCode("TAB");

        //    int sleep = 1;

        //    Send(0, 0, c, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);

        //    Send(0, 0, t, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);

        //    Send(0, 0, o, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);

        //    Send(0, 0, r, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);

        //    Send(0, 0, tab, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);

        //    Send(0, 0, tab, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(sleep);
        //}

        //public void SendCtrlKD()
        //{
        //    var ctrlKey = _keyboardUtils.GetModifierKeyCode("[LCTRL]");
        //    byte k = _keyboardUtils.GetKeyKeyCode("k");
        //    byte d = _keyboardUtils.GetKeyKeyCode("d");
        //    byte e = _keyboardUtils.GetKeyKeyCode("e");
        //    byte s = _keyboardUtils.GetKeyKeyCode("s");

        //    Send(ctrlKey, 0, k, d, 0, 0, 0, 0);
        //    Thread.Sleep(10);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(10);

        //    Send(ctrlKey, 0, k, e, 0, 0, 0, 0);
        //    Thread.Sleep(10);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //    Thread.Sleep(10);

        //    Send(ctrlKey, 0, s, 0, 0, 0, 0, 0);
        //    Thread.Sleep(10);
        //    Send(0, 0, 0, 0, 0, 0, 0, 0);
        //}

        public void SendEmpty()
        {
            Send(0, 0, 0, 0, 0, 0, 0, 0);
        }

        public void Send(Byte Modifier, Byte Padding, Byte Key0, Byte Key1, Byte Key2, Byte Key3, Byte Key4, Byte Key5)
        {
            SetFeatureKeyboard KeyboardData = new SetFeatureKeyboard();
            KeyboardData.ReportID = 1;
            KeyboardData.CommandCode = 2;
            KeyboardData.Timeout = 1000; //5 because we count in blocks of 5 in the driver
            KeyboardData.Modifier = Modifier;
            //padding should always be zero.
            KeyboardData.Padding = Padding;
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
