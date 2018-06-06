using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVerifierLibrary.Graph
{
    /// <summary>
    /// Implements A* search Algorithm
    /// </summary>
    class AStarSearch<T> where T : IComparable
    {
        private PriorityQueue<T> Open;

        public AStarSearch()
        {
            Open = new PriorityQueue<T>();
        }

        private void InitSearch(Node<T> Root)
        {
            Open.Add(Root);
        }

        public Node<T> Search(Node<T> Root, Node<T> Goal)
        {
            if (Open.Count == 0)
            {
                InitSearch(Root);
            }
            while (Open.Count != 0)
            {
                var Current = Open.Pop();
                if (Current.IsEqual(Goal.Value))
                {
                    return Current;
                }
                var _Children = Current.Children;
                foreach (var _Child in _Children)
                {
                    Open.Add(_Child);
                }
            }
            return Goal;
        }
    }
}
