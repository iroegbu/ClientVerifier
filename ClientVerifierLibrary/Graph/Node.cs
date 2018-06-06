using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Graph
{
    public class Node<T> where T : IComparable
    {
        private int cost;
        public T Value { get; set; }
        public string Label { get; set; }
        public int Cost
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Cost + cost;
                }
                else
                {
                    return cost;
                }
            }
            set { cost = value; }
        }
        public int Heuristics { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
        public bool IsEqual(T Value)
        {
            return Value.CompareTo(Value) == 0;
        }
    }
}
