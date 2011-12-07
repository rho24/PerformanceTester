using System;
using System.Threading;
using PerformanceTester;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new ConsoleTester();

            tester.ComparisonTest(Test1, Test2);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        
        static void Test1()
        {
            var rand = new Random();
            Thread.Sleep((int) (rand.NextDouble()*50));
        }
        static void Test2()
        {
            var rand = new Random();
            Thread.Sleep((int) (rand.NextDouble()*60));
        }
    }
}