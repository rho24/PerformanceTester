using System;

namespace PerformanceTester
{
    public static class RandomHelper
    {
        static readonly Random _rand = new Random();

        public static bool TrueOrFalse()
        {
            return _rand.NextDouble() >= 0.5;
        }
    }
}