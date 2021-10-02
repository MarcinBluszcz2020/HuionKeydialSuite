﻿using HKS.Core;
using System;
using System.Threading;

namespace HuionKeydialSuite.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var huion = new HKS.Core.Huion.HuionKD100();
            var hvdk = new HKS.Core.Hvdk.HvdkDevice();

            var reportHandler = new HuionReportHandler(huion, new HKS.Core.Hvdk.KeystrokeHelper(hvdk));

            var cts = new CancellationTokenSource();

            while (cts.IsCancellationRequested == false)
            {
                cts.Token.WaitHandle.WaitOne();
            }

            Console.WriteLine("Main end - press any key to exit...");
            Console.ReadLine();
        }
    }
}
