using System;
using System.Collections;

namespace PerformanceTester
{
    public class TestSettings
    {
        public int Iterations { get; set; }

        public TestSettings()
        {
            Iterations = 100;
        }
    }
}