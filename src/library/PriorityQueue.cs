using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class PriorityQueue<T>
    {
        readonly List<T> _heap = new List<T>();
        readonly Comparison<T> _comparison;

        public PriorityQueue(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public PriorityQueue() : this(Comparer<T>.Default.Compare) { }

        public PriorityQueue(IComparer<T> comparer) : this(comparer.Compare) { }

        public void Enqueue(T item)
        {
            _heap.Add(item);

            int childID = _heap.Count - 1;
            int parentID = (childID - 1) / 2;

            while (childID > 0 && _comparison(_heap[parentID], _heap[childID]) > 0)
            {
                Swap(parentID, childID);
                childID = parentID;
                parentID = (parentID - 1) / 2;
            }
        }

        public T Dequeue()
        {
            var first = _heap.First();
            _heap[0] = _heap.Last();
            _heap.RemoveAt(_heap.Count - 1);

            int parentID = 0;
            int childID = parentID * 2 + 2;
            if (childID >= _heap.Count || _comparison(_heap[childID], _heap[childID - 1]) > 0) childID--;

            while (childID < _heap.Count && _comparison(_heap[parentID], _heap[childID]) > 0)
            {
                Swap(parentID, childID);
                parentID = childID;
                childID = parentID * 2 + 2;
                if (childID >= _heap.Count || _comparison(_heap[childID], _heap[childID - 1]) > 0) childID--;
            }

            return first;
        }

        void Swap(int parent, int child)
        {
            var tmp = _heap[parent];
            _heap[parent] = _heap[child];
            _heap[child] = tmp;
        }

        public T Peek() { return _heap[0]; }
        public int Count => _heap.Count;
        public bool Any() { return _heap.Any(); }
        public List<T> Data => _heap;
    }
}
