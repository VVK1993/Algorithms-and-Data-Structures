using AlgTrains.DataStructures;
using AlgTrains.Helper;
using AlgTrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week4
{
    public class GraphSCCConnector : ITaskPerformer
    {
        private int vertex;
        private Dictionary<int, List<int>> outgoing = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> incoming = new Dictionary<int, List<int>>();
        private HashSet<int> visitedVertices = new HashSet<int>();
        private Stack<int> excludedVertices = new Stack<int>();
        private List<DirectedEdge> adjacencyList;

        public IEnumerable<List<int>> FindConnectedComponents()
        {
            var minEdge = adjacencyList.Min();
            var maxEdge = adjacencyList.Max();
            var min = Math.Min(minEdge.A, minEdge.B);
            var max = Math.Max(maxEdge.A, maxEdge.B);

            for (var i = min; i <= max; ++i)
            {
                outgoing.Add(i, new List<int>());
                incoming.Add(i, new List<int>());
            }

            foreach (var edge in adjacencyList)
            {
                outgoing[edge.A].Add(edge.B);
                incoming[edge.B].Add(edge.A);
            }

            for (var i = max; i >= min; --i)
            {
                if (visitedVertices.Contains(i)) continue;
                DFS1(i);
            }

            visitedVertices.Clear();

            while (excludedVertices.Any())
            {
                vertex = excludedVertices.Pop();
                if (visitedVertices.Contains(vertex)) continue;

                var list = new List<int>();
                DFS2(vertex, list);
                yield return list;
            }
        }

        private void DFS2(int i, List<int> list)
        {
            visitedVertices.Add(i);
            list.Add(i);
            foreach (var j in outgoing[i])
            {
                if (visitedVertices.Contains(j)) continue;
                DFS2(j, list);
            }
        }

        private void DFS1(int i)
        {
            visitedVertices.Add(i);
            foreach (var j in incoming[i])
            {
                if (visitedVertices.Contains(j)) continue;
                DFS1(j);
            }
            excludedVertices.Push(i);
        }

        public string TaskDescription
        {
            get { return "Task 4: Computing Strongly Connected Components"; }
        }

        public string FileName
        {
            get { return "SCC.txt"; }
        }

        /// <summary>
        /// Performs all tasks for Week 4 "Algorithms: Design and Analysis, Part 1" course
        /// </summary>
        public Task PerformTask()
        {
            adjacencyList = FileReader.ReadAdjacencyList(@"Assets/" + FileName);

            var t = new Thread(InternalRun, 200 << 20);
            t.Start();
            t.Join();

            return Task.FromResult(true);
        }

        private void InternalRun()
        {
            Benchmark.Start(TaskDescription);
            var components = FindConnectedComponents().ToList();
            Console.WriteLine("Sizes of the largest components are: {0}", string.Join(",", components.Select(l => l.Count).OrderByDescending(l => l).Take(5)));
            Console.WriteLine("Total size of components is: {0}", components.Select(c => c.Count).Sum());
            Benchmark.Finish();
        }

    }
}
