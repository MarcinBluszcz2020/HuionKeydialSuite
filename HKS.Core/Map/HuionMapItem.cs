using HKS.Core.Huion;
using System.Collections.Generic;

namespace HKS.Core.Map
{
    public class HuionMapItem
    {
        public HuionKey Key { get; set; }
        public HuionMapItemType Type { get; set; }
        public List<string> Keystroke { get; set; }
    }
}