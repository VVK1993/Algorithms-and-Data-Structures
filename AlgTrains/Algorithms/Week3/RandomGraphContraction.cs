using AlgTrains.DataStructures;
using AlgTrains.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week3
{
    public class RandomGraphContraction
    {
        private const int AMOUNT_OF_ATTEMPTS = 100;
        private const string fileName = "kargerMinCut.txt";

        /// <summary>
        /// Performs all tasks for Week 3 "Algorithms: Design and Analysis, Part 1" course
        /// </summary>
        public static async void PerformAllTasks()
        {
            var vertices = await FileReader.ReadVertexArray(@"Assets/" + fileName);

            if (vertices != null)
            {
                /* karger contraction */
                int minCutSize = int.MaxValue;

                for (int i = 0; i < AMOUNT_OF_ATTEMPTS; i++)
                {
                    var currentCut = CalculateMinCut(vertices.Clone<Vertex>());
                    if (currentCut < minCutSize)
                        minCutSize = currentCut;
                }

                Console.WriteLine(minCutSize);
            }
        }

        /// <summary>
        /// Running Time Omega(n^2*m)
        /// slow algorithm which often produces wrong results
        /// </summary>
        /// <param name="vertices"></param>
        /// <returns></returns>
        public static int CalculateMinCut(List<Vertex> vertices)
        {
            try
            {
                while (vertices.Count > 2)
                {
                    var randomVertices = PickRandomVertices(vertices);
                    MergeTwoVertices(vertices, randomVertices.Item1, randomVertices.Item2);
                    RemoveSelfLoops(vertices);
                }

                return vertices[0].Edges.Count;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        private static void RemoveSelfLoops(List<Vertex> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Edges.Contains(vertices[i].Number))
                {
                    vertices[i].Edges.Remove(vertices[i].Number);
                    i--;
                }
            }
        }

        private static void MergeTwoVertices(List<Vertex> vertices, Vertex v1, Vertex v2)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Number != v2.Number)
                {
                    for (int j = 0; j < vertices[i].Edges.Count; j++)
                    {
                        if (vertices[i].Edges[j] == v2.Number)
                            vertices[i].Edges[j] = v1.Number;
                    }
                }
            }

            for (int i = 0; i < v2.Edges.Count; i++)
            {
                v1.Edges.Add(v2.Edges[i]);
            }

            vertices.Remove(v2);
        }

        /// <summary>
        /// randomly picks two vertices
        /// </summary>
        /// <param name="vertices"></param>
        /// <returns>Tuple consists of 2 vertecies choosen randomly</returns>
        private static Tuple<Vertex, Vertex> PickRandomVertices(List<Vertex> vertices)
        {
            var rd = new Random();

            int v1 = rd.Next(vertices.Count);
            int v2 = rd.Next(vertices[v1].Edges.Count);

            var vertex1 = vertices[v1];
            var vertex2 = vertices.Where((x) => x.Number == vertex1.Edges[v2]).First();

            return new Tuple<Vertex, Vertex>(vertex1, vertex2);
        }
    }
}
