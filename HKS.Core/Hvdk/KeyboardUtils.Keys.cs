using System.Collections.Generic;

namespace HKS.Core.Hvdk
{
    public partial class KeyboardUtils
    {
        public static class Keys
        {
            private static List<string> _keys;

            static Keys()
            {
                _keys = new List<string>();

                _keys.Add("dummy1");
                _keys.Add("dummy2");
                _keys.Add("dummy3");
                _keys.Add("dummy4");
                _keys.Add("a");
                _keys.Add("b");
                _keys.Add("c");
                _keys.Add("d");
                _keys.Add("e");
                _keys.Add("f");
                _keys.Add("g");
                _keys.Add("h");
                _keys.Add("i");
                _keys.Add("j");
                _keys.Add("k");
                _keys.Add("l");
                _keys.Add("m");
                _keys.Add("n");
                _keys.Add("o");
                _keys.Add("p");
                _keys.Add("q");
                _keys.Add("r");
                _keys.Add("s");
                _keys.Add("t");
                _keys.Add("u");
                _keys.Add("v");
                _keys.Add("w");
                _keys.Add("x");
                _keys.Add("y");
                _keys.Add("z");
                _keys.Add("1");
                _keys.Add("2");
                _keys.Add("3");
                _keys.Add("4");
                _keys.Add("5");
                _keys.Add("6");
                _keys.Add("7");
                _keys.Add("8");
                _keys.Add("9");
                _keys.Add("0");
                _keys.Add("ENTER");
                _keys.Add("ESCAPE");
                _keys.Add("BACKSPACE");
                _keys.Add("TAB");
                _keys.Add("SPACEBAR");
                _keys.Add("-");
                _keys.Add("=");
                _keys.Add("[");
                _keys.Add("]");
                _keys.Add("\\");
                _keys.Add("");
                _keys.Add(";");
                _keys.Add("dummy5");
                _keys.Add("`");
                _keys.Add(",");
                _keys.Add(".");
                _keys.Add("/");
                _keys.Add("CAPSLOCK");
                _keys.Add("F1");
                _keys.Add("F2");
                _keys.Add("F3");
                _keys.Add("F4");
                _keys.Add("F5");
                _keys.Add("F6");
                _keys.Add("F7");
                _keys.Add("F8");
                _keys.Add("F9");
                _keys.Add("F10");
                _keys.Add("F11");
                _keys.Add("F12");
                _keys.Add("PRINTSCREEN");
                _keys.Add("SCROLLLOCK");
                _keys.Add("PAUSE");
                _keys.Add("INSERT");
                _keys.Add("HOME");
                _keys.Add("PAGEUP");
                _keys.Add("DELETE");
                _keys.Add("END");
                _keys.Add("PAGEDOWN");
                _keys.Add("RIGHTARROW");
                _keys.Add("LEFTARROW");
                _keys.Add("DOWNARROW");
                _keys.Add("UPARROW");
                _keys.Add("NUMLOCK");
                _keys.Add("K/");
                _keys.Add("K*");
                _keys.Add("K-");
                _keys.Add("K+");
                _keys.Add("KENTER");
                _keys.Add("K1");
                _keys.Add("K2");
                _keys.Add("K3");
                _keys.Add("K4");
                _keys.Add("K5");
                _keys.Add("K6");
                _keys.Add("K7");
                _keys.Add("K8");
                _keys.Add("K9");
                _keys.Add("K0");
                _keys.Add("K.");
                _keys.Add("F13");
                _keys.Add("F14");
                _keys.Add("F15");
                _keys.Add("F16");
                _keys.Add("F17");
                _keys.Add("F18");
                _keys.Add("F19");
                _keys.Add("F20");
                _keys.Add("F21");
                _keys.Add("F22");
                _keys.Add("F23");
                _keys.Add("F24"); //115
            }

            public static byte? GetKeyCode(string key)
            {
                int index = _keys.IndexOf(key);

                if (index == -1)
                {
                    return null;
                }
                else
                {
                    return (byte)index;
                };
            }

            public static IEnumerable<string> GetKeys()
            {
                return _keys.AsReadOnly();
            }
        }
    }
}
