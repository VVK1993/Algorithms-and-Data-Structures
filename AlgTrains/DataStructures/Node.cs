using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class Node
    {
        public int Number { get; set; }
        public bool IsExplored { get; set; }

        public Node(int n, bool explored = false)
        {
            Number = n;
            IsExplored = explored;
        }
    }
}
