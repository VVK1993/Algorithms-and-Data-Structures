using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Helper
{
    public class Benchmark
    {
        private static Stopwatch stopWatch;
        private static string benchmarkName;

        public static void Start(string name)
        {
            benchmarkName = name;
            stopWatch = Stopwatch.StartNew();
        }

        public static void Finish()
        {
            stopWatch.Stop();
            Console.WriteLine(string.Format("{0} completed in: {1} ms", benchmarkName, stopWatch.ElapsedMilliseconds));
        }
    }
}
