using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{

    public class UnionFind
    {
        public int[] Parents { get; set; }
        public UnionFind(int size)
        {
            Parents = Enumerable.Repeat(-1, size).ToArray();
        }

        public int Find(int num)
        {
            if (Parents[num] < 0) return num;

            Parents[num] = Find(Parents[num]);
            return Parents[num];
        }

        public int Size(int num)
        {
            return -Parents[Find(num)];
        }

        public bool Same(int a, int b)
        {
            return Find(a) == Find(b);
        }

        public void Unite(int a, int b)
        {
            int x = Find(a), y = Find(b);
            if (x == y) return;

            if (Size(x) > Size(y))
            {
                Parents[x] += Parents[y];
                Parents[y] = x;
            }
            else
            {
                Parents[y] += Parents[x];
                Parents[x] = y;
            }
        }
    }
}
