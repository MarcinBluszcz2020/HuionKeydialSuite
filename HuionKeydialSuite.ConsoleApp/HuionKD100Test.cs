using HKS.Core.Huion;
using System.Text;
using System.Threading;

namespace HuionKeydialSuite.ConsoleApp
{
    public class HuionKD100Test
    {
        public static void Test()
        {
            var huionDevice = new HuionKD100();

            huionDevice.KeyReport += HuionDevice_ReportReceived;
            huionDevice.DialClockwiseTick += HuionDevice_DialClockwiseTick;
            huionDevice.DialCounterClockwiseTick += HuionDevice_DialCounterClockwiseTick;

            var cancellationTokenSource = new CancellationTokenSource();

            while (cancellationTokenSource.IsCancellationRequested == false)
            {
                cancellationTokenSource.Token.WaitHandle.WaitOne();
            }
        }

        private static void HuionDevice_DialCounterClockwiseTick(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Huion KD100 Dial CounterClockwise Tick");
        }

        private static void HuionDevice_DialClockwiseTick(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Huion KD100 Dial Clockwise Tick");
        }

        private static void HuionDevice_ReportReceived(object sender, HuionKeyReport e)
        {
            var sb = new StringBuilder();

            sb.Append("Huion KD100 report: ");

            if (e.A0) { sb.Append("A0 "); }
            if (e.A1) { sb.Append("A1 "); }
            if (e.A2) { sb.Append("A2 "); }
            if (e.A3) { sb.Append("A3 "); }
            if (e.A4) { sb.Append("A4 "); }
            if (e.A5) { sb.Append("A5 "); }
            if (e.A6) { sb.Append("A6 "); }
            if (e.A7) { sb.Append("A7 "); }

            if (e.B0) { sb.Append("B0 "); }
            if (e.B1) { sb.Append("B1 "); }
            if (e.B2) { sb.Append("B2 "); }
            if (e.B3) { sb.Append("B3 "); }
            if (e.B4) { sb.Append("B4 "); }
            if (e.B5) { sb.Append("B5 "); }
            if (e.B6) { sb.Append("B6 "); }
            if (e.B7) { sb.Append("B7 "); }

            if (e.C0) { sb.Append("C0 "); }
            if (e.C1) { sb.Append("C1 "); }
            if (e.C2) { sb.Append("C2 "); }

            System.Console.WriteLine(sb);
        }
    }
}
