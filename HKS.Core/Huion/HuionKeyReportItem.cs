namespace HKS.Core.Huion
{
    public class HuionKeyReportItem
    {
        public HuionKey Key { get; }
        public bool State { get; }

        public HuionKeyReportItem(HuionKey key, bool state)
        {
            Key = key;
            State = state;
        }
    }
}