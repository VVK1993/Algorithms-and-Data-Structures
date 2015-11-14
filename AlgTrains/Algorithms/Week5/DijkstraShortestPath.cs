using AlgTrains.DataStructures;
using AlgTrains.Helper;
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

        public async Task PerformTask()
        {
            List<WeightedEdge> weightedEdges = await FileReader.ReadWeightedEdgesList(@"Assets/" + FileName);
            //vertices numbers required for this task
            int[] taskVertices = new int[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };

            if (weightedEdges != null)
            {
                Benchmark.Start(TaskDescription);
                var shortestPaths = Compute(weightedEdges);
                var shortestPathsToFind = taskVertices.Select(v => shortestPaths[v]).ToArray();
                Console.WriteLine("Shortest distances for task are {0}", string.Join(",", shortestPathsToFind));
                Benchmark.Finish();
            }
        }

        private int[] Compute(List<WeightedEdge> weightedEdges)
        {
            //constant given by task
            var weightConstant = 1000000;
            var maxVertexNumber = weightedEdges.Max().A;

            var edgesFrom = Enumerable.Range(1, maxVertexNumber).ToDictionary(i => i, i => weightedEdges.Where(e => e.A == i).ToList());
            var edgesTo = Enumerable.Range(1, maxVertexNumber).ToDictionary(i => i, i => weightedEdges.Where(e => e.B == i).ToList());
            var distances = Enumerable.Range(0, maxVertexNumber + 1).Select(i => weightConstant).ToArray();

            distances[1] = 0;
            var visited = new HashSet<int> { 1 };
            var explorableFront = new HashSet<int>();
            foreach (var edge in edgesFrom[1])
            {
                distances[edge.B] = Math.Min(distances[1] + edge.Weight, distances[edge.B]);
                explorableFront.Add(edge.B);
            }
            foreach (var edge in edgesTo[1])
            {
                distances[edge.A] = Math.Min(distances[1] + edge.Weight, distances[edge.A]);
                explorableFront.Add(edge.A);
            }

            while (explorableFront.Any())
            {
                var vertex = explorableFront.OrderBy(v => distances[v]).First();

                foreach (var edge in edgesFrom[vertex])
                {
                    distances[edge.B] = Math.Min(distances[vertex] + edge.Weight, distances[edge.B]);
                    if (!visited.Contains(edge.B)) explorableFront.Add(edge.B);

                }
                foreach (var edge in edgesTo[vertex])
                {
                    distances[edge.A] = Math.Min(distances[vertex] + edge.Weight, distances[edge.A]);
                    if (!visited.Contains(edge.A)) explorableFront.Add(edge.A);
                }

                explorableFront.Remove(vertex);
                visited.Add(vertex);
            }

            return distances;
        }
    }
}
