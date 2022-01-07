using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Permutation
    {
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int num)
        {
            if (items.Count() < num || num <= 0)
            {
                yield return new T[0];
                yield break;
            }
            foreach (var item in items)
            {
                var leftside = new T[] { item };
                var unused = items.Except(leftside);
                foreach (var rightside in Enumerate(unused, num - 1))
                {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}