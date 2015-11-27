using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AlgTrains.Algorithms.Week3;
using AlgTrains.DataStructures;

// Author: Vladimir Kovtunovskiy
namespace AlgTrains.Helper
{
    public class FileReader
    {
        /// <summary>
        /// Reads file that consists of integer numbers
        /// </summary>
        /// <param name="fileName">name of the specific file to read</param>
        /// <returns>array of integers</returns>
        public static async Task<int[]> ReadIntegerArray(string fileName)
        {
            try
            {
                List<int> integers = new List<int>();

                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var value = await stream.ReadLineAsync();
                        integers.Add(Int32.Parse(value));
                    }
                }

                return integers.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// read data for week 3 task
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<List<Vertex>> ReadVertexArray(string fileName)
        {
            try
            {
                List<Vertex> vertices = new List<Vertex>();

                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = await stream.ReadLineAsync();
                        var values = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        int n = Int32.Parse(values[0]);
                        List<int> edges = new List<int>();

                        for (int i = 1; i < values.Length; i++)
                        {
                            edges.Add(Int32.Parse(values[i]));
                        }

                        vertices.Add(new Vertex(n, edges));
                    }
                }

                return vertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// read data for week 4 task
        /// </summary>
        public static List<DirectedEdge> ReadAdjacencyList(string fileName)
        {
           try
            {
                var adjacencyList = new List<DirectedEdge>();

                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = stream.ReadLine();
                        var values = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        adjacencyList.Add(new DirectedEdge(values[0], values[1]));
                    }
                }

                return adjacencyList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// read and prepare data for week 5 task
        /// </summary>
        internal static async Task<List<WeightedEdge>> ReadWeightedEdgesList(string fileName)
        {
            try
            {
                var weightedEdges = new List<WeightedEdge>();

                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var line = await stream.ReadLineAsync();
                        var values = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        weightedEdges.AddRange(
                        values.Skip(1).Select(s => s.Split(new[] { ',' }))
                            .Select(a => new WeightedEdge(int.Parse(values[0]), int.Parse(a[0]), int.Parse(a[1]))).ToList());
                    }
                }

                return weightedEdges;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Reads file that consists of long numbers
        /// </summary>
        /// <param name="fileName">name of the specific file to read</param>
        /// <returns>array of longs</returns>
        public static async Task<long[]> ReadLongArray(string fileName)
        {
            try
            {
                List<long> integers = new List<long>();

                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var value = await stream.ReadLineAsync();
                        integers.Add(long.Parse(value));
                    }
                }

                return integers.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
