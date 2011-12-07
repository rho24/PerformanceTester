using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace PerformanceTester
{
    public class ConsoleTester
    {
        public void ComparisonTest(Action test1, Action test2, TestSettings settings = null)
        {
            settings = settings ?? new TestSettings();

            Console.WriteLine("Running tests");
            var consoleCursorTop = Console.CursorTop;

            var test1Results = new Collection<TestResult>();
            var test2Results = new Collection<TestResult>();
            foreach (var iteration in Enumerable.Range(1, settings.Iterations))
            {
                Console.SetCursorPosition(0, consoleCursorTop);
                Console.WriteLine("Running iteration {0}", iteration);
                var swapOrder = RandomHelper.TrueOrFalse();
                if (swapOrder)
                {
                    test2Results.Add(RunTest(test2));
                    test1Results.Add(RunTest(test1));
                }
                else
                {
                    test1Results.Add(RunTest(test1));
                    test2Results.Add(RunTest(test2));
                }
            }
            Console.SetCursorPosition(0, consoleCursorTop);
            Console.WriteLine("".PadRight(Console.BufferWidth - 1));

            var averageTest1 = test1Results.Average(r => r.Elapsed.TotalSeconds);
            var averageTest2 = test2Results.Average(r => r.Elapsed.TotalSeconds);

            Console.WriteLine("Test 1 average: {0}", averageTest1);
            Console.WriteLine("Test 2 average: {0}", averageTest2);
        }

        TestResult RunTest(Action test)
        {
            var watch = Stopwatch.StartNew();
            test();
            watch.Stop();
            return new TestResult {Elapsed = watch.Elapsed};
        }
    }
}