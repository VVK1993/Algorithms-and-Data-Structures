using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class DirectedEdge : IComparable<DirectedEdge>
    {
        public int A { get; set; }
        public int B { get; set; }

        public DirectedEdge(int a, int b)
        {
            A = a;
            B = b;
        }

        protected bool Equals(DirectedEdge other)
        {
            return A == other.A && B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DirectedEdge)obj);
        }


        public int CompareTo(DirectedEdge other)
        {
            if (this.A > other.A || this.B > other.B)
                return 1;
            else if (this.A < other.A || this.B < other.B)
                return -1;
            return 0;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (A * 397) ^ B;
            }
        }
    }
}
