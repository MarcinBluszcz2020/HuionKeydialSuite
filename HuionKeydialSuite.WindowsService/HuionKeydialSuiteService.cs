using HKS.Core;
using HKS.Core.Hvdk;
using System.Diagnostics;
using System.ServiceProcess;

namespace HuionKeydialSuite.WindowsService
{
    public partial class HuionKeydialSuiteService : ServiceBase
    {
        private readonly EventLog _eventLog;

        public HuionKeydialSuiteService()
        {
            InitializeComponent();

            _eventLog = new System.Diagnostics.EventLog();

            if (!System.Diagnostics.EventLog.SourceExists("HuionKeydialSuite"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "HuionKeydialSuite", "HuionKeydialSuiteLog");
            }

            _eventLog.Source = "HuionKeydialSuite";
            _eventLog.Log = "HuionKeydialSuiteLog";
        }

        protected override void OnStart(string[] args)
        {
            _eventLog.WriteEntry("In OnStart");

            var huion = new HKS.Core.Huion.HuionKD100();
            var hvdk = new HKS.Core.Hvdk.HvdkDevice();

            var reportHandler = new HuionReportHandler(huion, new KeystrokeSender(hvdk), MapHelper.GetMap());
        }

        protected override void OnStop()
        {
        }
    }
}
