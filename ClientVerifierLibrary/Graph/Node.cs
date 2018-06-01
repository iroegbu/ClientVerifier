using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Graph
{
    class Node<T>
    {
        public T Value { get; set; }
        public int Cost { get; set; }
        public int Heuristics { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
    }
}
