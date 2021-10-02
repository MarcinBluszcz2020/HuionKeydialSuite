using HKS.Core;
using HKS.Core.Hvdk;
using HKS.Core.Map;
using System.Threading;

namespace HuionKeydialSuite.ConsoleApp
{
    public class HvdkTest
    {
        public static void Test()
        {
            var helpText = KeyboardUtils.GetKeysHelpXmlString();

            var mapConfiguration = new HuionMap();

            mapConfiguration.A0 = new HuionMapItem
            {
                Type = HuionMapItemType.Keyboard,
                Keystroke = "[LSHIFT]+s"
            };

            var existing = MapHelper.GetMap();
            MapHelper.SaveMap(mapConfiguration);

            var device = new HKS.Core.Hvdk.HvdkDevice();

            var keystrokeHelper = new KeystrokeHelper(device);

            keystrokeHelper.SendKeystroke("[LSHIFT]+s");
        }
    }
}