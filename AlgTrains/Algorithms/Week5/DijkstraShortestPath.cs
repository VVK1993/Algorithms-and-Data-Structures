using AlgTrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week5
{
    public class DijkstraShortestPath : ITaskPerformer
    {
        public string TaskDescription
        {
            get { return "Task 5: Computing Dijkstra's Shortest Path"; }
        }

        public string FileName
        {
            get { return "dijkstraData.txt"; }
        }

        public Task PerformTask()
        {
            throw new NotImplementedException();
        }
    }
}
