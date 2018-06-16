using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactVerifierLibrary.Graph
{
    /// <summary>
    /// Implements A* search Algorithm
    /// </summary>
    public class AStarSearch<T> where T : IComparable
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
            var Closed = new List<Node<T>>();
            while (Open.Count != 0)
            {
                var Current = Open.Pop();
                if (Current.IsEqual(Goal.Value))
                {
                    return Current;
                }
                Closed.Add(Current);
                var _Children = Current.Children;
                foreach (var _Child in _Children)
                {
                    if (Closed.Contains(_Child))
                    {
                        var OldEntry = Closed.Find(x => x.IsEqual(_Child.Value));
                        if (_Child.Weight < OldEntry.Weight)
                        {
                            Open.Add(_Child);
                        }
                    } else
                    {
                        Open.Add(_Child);
                    }
                }
            }
            return Goal;
        }
    }
}
