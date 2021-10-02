using System.Collections.Generic;

namespace HKS.Core.Hvdk
{
    public partial class KeyboardUtils
    {
        public class ModifierKeys
        {
            public const byte LCTRL = 0x01;
            public const byte LSHIFT = 0x02;
            public const byte LALT = 0x03;
            public const byte LWIN = 0x04;
            public const byte RCTRL = 0x05;
            public const byte RSHIFT = 0x06;
            public const byte RALT = 0x07;
            public const byte RWIN = 0x08;

            private static List<string> _keys;

            static ModifierKeys()
            {
                _keys = new List<string>();

                _keys.Add("dummy1");
                _keys.Add("[LCTRL]");
                _keys.Add("[LSHIFT]");
                _keys.Add("[LALT]");
                _keys.Add("[LWIN]");
                _keys.Add("[RCTRL]");
                _keys.Add("[RSHIFT]");
                _keys.Add("[RALT]");
                _keys.Add("[RWIN]");
            }

            public static byte? GetModifierKeyCode(string modifier)
            {
                int i = _keys.IndexOf(modifier);
                if (i == -1)
                {
                    return null;
                }
                else
                {
                    return (byte)i;
                };
            }

            public static IEnumerable<string> GetKeys()
            {
                return _keys.AsReadOnly();
            }
        }
    }
}
