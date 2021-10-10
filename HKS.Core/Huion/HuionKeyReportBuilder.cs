using System.Collections.Generic;

namespace HKS.Core.Huion
{
    public class HuionKeyReportBuilder
    {
        private readonly List<HuionKeyReportItem> _reportItems;

        public HuionKeyReportBuilder()
        {
            _reportItems = new List<HuionKeyReportItem>();
        }

        public HuionKeyReportBuilder KeyState(HuionKey key, bool state)
        {
            _reportItems.RemoveAll(o => o.Key == key);
            _reportItems.Add(new HuionKeyReportItem(key, state));

            return this;
        }

        public HuionKeyReport BuildReport()
        {
            return new HuionKeyReport(_reportItems);
        }
    }
}
