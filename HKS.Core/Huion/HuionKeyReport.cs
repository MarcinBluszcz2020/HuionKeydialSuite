using System.Collections.Generic;
using System.Linq;

namespace HKS.Core.Huion
{
    public class HuionKeyReport
    {
        public IReadOnlyCollection<HuionKey> PressedKeys { get; }

        private IEnumerable<HuionKeyReportItem> Items { get; }

        public HuionKeyReport(IEnumerable<HuionKeyReportItem> items)
        {
            Items = items;
            PressedKeys = items.Where(o => o.State).Select(o => o.Key).ToList().AsReadOnly();
        }

        public bool A0 => GetKeyState(HuionKey.A0);
        public bool A1 => GetKeyState(HuionKey.A1);
        public bool A2 => GetKeyState(HuionKey.A2);
        public bool A3 => GetKeyState(HuionKey.A3);
        public bool A4 => GetKeyState(HuionKey.A4);
        public bool A5 => GetKeyState(HuionKey.A5);
        public bool A6 => GetKeyState(HuionKey.A6);
        public bool A7 => GetKeyState(HuionKey.A7);

        public bool B0 => GetKeyState(HuionKey.B0);
        public bool B1 => GetKeyState(HuionKey.B1);
        public bool B2 => GetKeyState(HuionKey.B2);
        public bool B3 => GetKeyState(HuionKey.B3);
        public bool B4 => GetKeyState(HuionKey.B4);
        public bool B5 => GetKeyState(HuionKey.B5);
        public bool B6 => GetKeyState(HuionKey.B6);
        public bool B7 => GetKeyState(HuionKey.B7);

        public bool C0 => GetKeyState(HuionKey.C0);
        public bool C1 => GetKeyState(HuionKey.C1);
        public bool C2 => GetKeyState(HuionKey.C2);

        public bool GetKeyState(HuionKey key)
        {
            return Items.FirstOrDefault(o => o.Key == key)?.State ?? false;
        }
    }
}
