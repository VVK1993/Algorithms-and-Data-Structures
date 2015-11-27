using AlgTrains.Helper;
using AlgTrains.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week6
{
    public class TwoSumCounter : ITaskPerformer
    {
        HashSet<long> data;
        public string TaskDescription
        {
            get { return "Task 6.1: 2-Sum Counter"; }
        }

        public string FileName
        {
            get { return "algo1-programming_prob-2sum.txt"; }
        }

        public async Task PerformTask()
        {
            long[] array = await FileReader.ReadLongArray(@"Assets/" + FileName);

            if (array != null)
            {
                data = new HashSet<long>(array);
                Benchmark.Start(TaskDescription);
                Console.WriteLine(string.Format("Amount of unique 2-sum pairs: {0}", ComputeTwoSum(array)));
                Benchmark.Finish();
            }
        }

        /// <summary>
        /// Task is to compute the number of target values t in the interval [-10000,10000] (inclusive) 
        /// such that there are distinct numbers x,y in the input file that satisfy x+y=t. 
        /// </summary>
        private int ComputeTwoSum(long[] array)
        {
            HashSet<long> data = new HashSet<long>(array);
            int sumCounter = 0;

            for (int t = -10000; t <= 10000; t++)
            {
                if (data.Any(key => key != t - key && data.Contains(t - key)))
                {
                    sumCounter++;
                }
            }

            return sumCounter;
        }

        public bool ContainsDistinctPairWithSum(int t)
        {
            return data.Any(x => x != t - x && data.Contains(t - x));
        }
    }
}
