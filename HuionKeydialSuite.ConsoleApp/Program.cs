using System;

namespace HuionKeydialSuite.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HuionKD100Test.Test();

            Console.WriteLine("Main end - press any key to exit...");
            Console.ReadLine();
        }
    }
}
