using AlgTrains.DataStructures;
using AlgTrains.Helper;
using AlgTrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week4
{
    /// <summary>
    /// Contains DFS and BFS Graph Search Algorithms
    /// </summary>
    public class GraphSearch 
    {
        private static bool ContainsUnexploredVertices(List<Vertex> vertices)
        {
            foreach (var v in vertices)
            {
                if (!v.IsExplored)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Running Time = O(n + m) linear time
        /// </summary>
        public static void BreadFirstSearch(List<Vertex> vertices)
        {
            var firstNode = vertices.First();
            firstNode.IsExplored = true;
            var verticesQueue = new Queue<Vertex>();
            verticesQueue.Enqueue(firstNode);
            while (verticesQueue.Count != 0)
            {
                var currentVertex = verticesQueue.Dequeue();
                foreach (var edge in currentVertex.Edges)
                {
                    var newVertex = vertices.Find((x) => x.Number == edge);
                    if (!newVertex.IsExplored)
                    {
                        newVertex.IsExplored = true;
                        verticesQueue.Enqueue(newVertex);
                    }
                }
            }
        }

        /// <summary>
        /// Running Time = O(n + m) linear time
        /// </summary>
        public static void DepthFirstSearch(List<Vertex> vertices, Vertex startVertex, Vertex leader, ref int counter)
        {
            startVertex.IsExplored = true;
            startVertex.Leader = leader;

            foreach (var edge in startVertex.Edges)
            {
                var newVertex = vertices.Find((x) => x.Number == edge);
                if (!newVertex.IsExplored)
                {
                    DepthFirstSearch(vertices, newVertex, leader, ref counter);
                }
            }
            counter++;
            startVertex.Label = counter.ToString();

        }

        private static void DFSLoop(List<Vertex> vertices)
        {
            //number of nodes processed so far
            int counter = 0;
            //current source vertex
            Vertex currentVertex = null;

            foreach (var v in vertices)
            {
                if (!v.IsExplored)
                {
                    currentVertex = v;
                    DepthFirstSearch(vertices, v, currentVertex, ref counter);
                }
            }
        }
    }
}
