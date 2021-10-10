using HKS.Core.Huion;
using System.Collections.Generic;
using System.Linq;

namespace HKS.Core.Map
{
    public class HuionMap
    {
        public List<HuionMapItem> Items { get; set; }

        public HuionMap()
        {
            Items = new List<HuionMapItem>();
        }

        public HuionMapItem GetKeyMapping(HuionKey key)
        {
            return Items.FirstOrDefault(o => o.Key == key);
        }
    }
}
