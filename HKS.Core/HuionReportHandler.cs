using HKS.Core.Huion;
using HKS.Core.Hvdk;
using HKS.Core.Map;

namespace HKS.Core
{
    public class HuionReportHandler
    {
        private readonly HuionKD100 _huionKD100;
        private readonly KeystrokeHelper _keystrokeHelper;
        private readonly HuionMap _map;

        public HuionReportHandler(HuionKD100 huionKD100, KeystrokeHelper keystrokeHelper, HuionMap keyMap)
        {
            _huionKD100 = huionKD100;
            _keystrokeHelper = keystrokeHelper;
            _map = keyMap;

            _huionKD100.KeyReport += _huionKD100_KeyReport;
        }

        private void _huionKD100_KeyReport(object sender, HuionKeyReport e)
        {
            foreach (var pressedKey in e.PressedKeys)
            {
                var keyMapping = _map.GetKeyMapping(pressedKey);

                if (keyMapping?.Type == HuionMapItemType.Keyboard)
                {
                    _keystrokeHelper.SendKeystroke(keyMapping.Keystroke);
                }
            }
        }
    }
}
