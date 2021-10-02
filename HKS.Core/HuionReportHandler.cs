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

        public HuionReportHandler(HuionKD100 huionKD100, KeystrokeHelper keystrokeHelper)
        {
            _huionKD100 = huionKD100;
            _keystrokeHelper = keystrokeHelper;
            _map = MapHelper.GetMap();

            _huionKD100.KeyReport += _huionKD100_KeyReport;
        }

        private void _huionKD100_KeyReport(object sender, HuionKeyReport e)
        {
            if (e.A0)
            {
                var mapItem = GetMapItem(HuionKey.A0);

                _keystrokeHelper.SendKeystroke(mapItem?.Keystroke);
            }

            if (e.A1)
            {
                var mapItem = GetMapItem(HuionKey.A1);

                _keystrokeHelper.SendKeystroke(mapItem?.Keystroke);
            }

            if (e.A2)
            {
                var mapItem = GetMapItem(HuionKey.A2);

                _keystrokeHelper.SendKeystroke(mapItem?.Keystroke);
            }

            if (e.A3)
            {
                var mapItem = GetMapItem(HuionKey.A3);

                _keystrokeHelper.SendKeystroke(mapItem?.Keystroke);
            }
        }

        private HuionMapItem GetMapItem(HuionKey huionKey)
        {
            switch (huionKey)
            {
                case HuionKey.A0:
                    return _map.A0;
                case HuionKey.A1:
                    return _map.A1;
                case HuionKey.A2:
                    return _map.A2;
                case HuionKey.A3:
                    return _map.A3;
                case HuionKey.A4:
                    return _map.A4;
                case HuionKey.A5:
                    return _map.A5;
                case HuionKey.A6:
                    return _map.A6;
                case HuionKey.A7:
                    return _map.A7;

                case HuionKey.B0:
                    return _map.B0;
                case HuionKey.B1:
                    return _map.B1;
                case HuionKey.B2:
                    return _map.B2;
                case HuionKey.B3:
                    return _map.B3;
                case HuionKey.B4:
                    return _map.B4;
                case HuionKey.B5:
                    return _map.B5;
                case HuionKey.B6:
                    return _map.B6;
                case HuionKey.B7:
                    return _map.B7;

                case HuionKey.C0:
                    return _map.C0;
                case HuionKey.C1:
                    return _map.C1;
                case HuionKey.C2:
                    return _map.C2;


                default:
                    return null;
            }
        }
    }
}
