using System;
using System.Collections.Generic;
using System.Threading;

namespace HKS.Core.Hvdk
{
    public class KeystrokeHelper
    {
        private readonly HvdkDevice _hvdkDevice;
        private readonly object _lock;

        public KeystrokeHelper(HvdkDevice hvdkDevice)
        {
            _hvdkDevice = hvdkDevice;
            _lock = new object();
        }

        public void SendKeystroke(List<string> keystrokeCollection)
        {
            if (keystrokeCollection == null)
            {
                return;
            }

            foreach (var keystroke in keystrokeCollection)
            {
                SendKeystroke(keystroke);
            }
        }

        public void SendKeystroke(string keystroke)
        {
            if (string.IsNullOrWhiteSpace(keystroke))
            {
                return;
            }

            var stringKeysToSend = keystroke.Split('+');

            if (stringKeysToSend.Length == 0)
            {
                return;
            }

            byte modifier = 0;
            List<byte> keys = new List<byte>();

            foreach (var stringKeyToSend in stringKeysToSend)
            {
                var asModifier = KeyboardUtils.ModifierKeys.GetModifierKeyCode(stringKeyToSend);

                if (asModifier.HasValue)
                {
                    modifier = asModifier.Value;
                    continue;
                }

                var asKey = KeyboardUtils.Keys.GetKeyCode(stringKeyToSend);

                if (asKey.HasValue)
                {
                    keys.Add(asKey.Value);
                }
            }

            Send(modifier, keys);
        }

        private void Send(byte modifier, List<byte> inputKeys)
        {
            if (inputKeys.Count > 6)
            {
                throw new NotImplementedException("Cannot handle more than 6 keys");
            }

            byte[] keysToSend = new byte[6];

            inputKeys.CopyTo(keysToSend);

            lock (_lock)
            {
                _hvdkDevice.Send(modifier, keysToSend[0], keysToSend[1], keysToSend[2], keysToSend[3], keysToSend[4], keysToSend[5]);

                Thread.Sleep(10);

                _hvdkDevice.SendEmpty();
            }
        }
    }
}
