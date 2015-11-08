using AlgTrains.Algorithms.Week1;
using AlgTrains.Algorithms.Week2;
using AlgTrains.Algorithms.Week3;
using AlgTrains.Algorithms.Week4;
using AlgTrains.Interfaces;
using AlgTrains.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Author: Vladimir Kovtunovskiy
namespace AlgTrains
{
    class Program
    {
        private static List<ITaskPerformer> courseraTasks;

        static void Main(string[] args)
        {
            InitializeAllTasks();
            PerformAllTasks();
            Console.ReadKey();
        }

        private static async void PerformAllTasks()
        {
            foreach (var t in courseraTasks)
            {
                Console.WriteLine(string.Format("{0} started.", t.TaskDescription));
                var task = Task.Run(() => t.PerformTask());
                Console.WriteLine("Awaiting task...");
                await task;
                Console.WriteLine(string.Format("{0} done.", t.TaskDescription));
            }
            Console.WriteLine("All tasks completed!");
        }

        private static void InitializeAllTasks()
        {
            courseraTasks = new List<ITaskPerformer>();
            courseraTasks.Add(new DivideAndConquer());
        }
    }
}
