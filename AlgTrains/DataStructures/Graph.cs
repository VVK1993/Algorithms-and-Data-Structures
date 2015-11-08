using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Tuple<int, int>> Edges { get; set; }
    }
}
