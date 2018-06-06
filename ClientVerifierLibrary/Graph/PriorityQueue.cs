using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Graph
{
    class PriorityQueue<T> : Collection<Node<T>> where T : IComparable
    {
        public Node<T> Pop()
        {
            var node = Items.OrderBy(n => n.Heuristics + n.Cost).First();
            Remove(node);
            return node;
        }
    }
}
