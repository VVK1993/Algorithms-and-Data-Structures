using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class WeightedEdge : IComparable
    {
        //first vertex
        public int A { get; set; }
        //second vertex
        public int B { get; set; }
        public int Weight { get; set; }

        public WeightedEdge(int a, int b, int w)
        {
            A = a;
            B = b;
            Weight = w;
        }

        public int CompareTo(object obj)
        {
            var other = obj as WeightedEdge;
            if (other != null)
            {
                if (this.A > other.A || this.B > other.B)
                    return 1;
                else if (this.A < other.A || this.B < other.B)
                    return -1;
                return 0;
            }
            else return -1;
        }
    }
}
