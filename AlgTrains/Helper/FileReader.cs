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

        public static async Task<List<Vertex>> ReadVertexArray(string fileName)
        {
            try
            {
                List<Vertex> vertexes = new List<Vertex>();

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

                        vertexes.Add(new Vertex(n, edges));
                    }
                }

                return vertexes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
