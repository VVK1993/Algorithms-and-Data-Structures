using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class Vertex : ICloneable
    {
        public int Number { get; set; }
        public List<int> Edges { get; set; }
        public bool IsExplored { get; set; }
        public Vertex Leader { get; set; }
        public string Label { get; set; }

        public Vertex(int n, List<int> edges)
        {
            // TODO: Complete member initialization
            this.Number = n;
            this.Edges = edges;
        }

        public object Clone()
        {
            return new Vertex(Number, Edges.ToList());
        }
    }
}
