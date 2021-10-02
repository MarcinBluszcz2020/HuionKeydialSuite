using HKS.Core.Hvdk;
using HKS.Core.Map;
using System;
using System.IO;

namespace HKS.Core
{
    public class MapHelper
    {
        private const string FileName = "mapConfig.xml";

        public static HuionMap GetMap()
        {
            if (File.Exists(FileName))
            {
                var loaded = SerializerHelper.DeserializeToObject<HuionMap>(FileName);

                return loaded;
            }
            else
            {
                var newMap = new HuionMap();
                SaveMap(newMap);

                return newMap;
            }
        }

        public static void SaveMap(HuionMap huionMap)
        {
            SerializerHelper.SerializeToXml(huionMap, FileName);

            var helpText = KeyboardUtils.GetKeysHelpXmlString();

            File.AppendAllText(FileName, helpText);
        }
    }
}
