using HKS.Core;
using HKS.Core.Hvdk;
using HKS.Core.Map;
using System.Collections.Generic;

namespace HuionKeydialSuite.ConsoleApp
{
    public class HvdkTest
    {
        public static void Test()
        {
            var helpText = KeyboardUtils.GetKeysHelpXmlString();

            var mapConfiguration = new HuionMap();

            mapConfiguration.Items.Add(new HuionMapItem
            {
                Type = HuionMapItemType.Keyboard,
                Keystroke = new List<string>() { "[LSHIFT]+s" }
            });

            var existing = MapHelper.GetMap();
            MapHelper.SaveMap(mapConfiguration);

            var device = new HKS.Core.Hvdk.HvdkDevice();

            var keystrokeHelper = new KeystrokeSender(device);

            keystrokeHelper.SendKeystroke("[LSHIFT]+s");
        }
    }
}