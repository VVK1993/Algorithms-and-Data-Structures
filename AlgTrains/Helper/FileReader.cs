using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

    }
}
