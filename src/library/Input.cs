using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Input
    {
        static IEnumerator<string> enumerator = new string[] { }.AsEnumerable().GetEnumerator();

        public static string Line => Console.ReadLine();

        public static string[] StrArr => Line.Split(' ');

        public static int NextInt => int.Parse(NextWord());

        public static long NextLong => long.Parse(NextWord());

        public static List<int> IntList => StrArr.Select(int.Parse).ToList();

        public static List<long> LongList => StrArr.Select(long.Parse).ToList();

        public static IEnumerable<long[]> TakeLine(int N)
        {
            return Enumerable.Repeat(0, N).Select(_ => Console.ReadLine().Split(' ').Select(long.Parse).ToArray());
        }

        public static string NextWord()
        {
            while (!enumerator.MoveNext())
            {
                enumerator = StrArr.AsEnumerable().GetEnumerator();
            }
            return enumerator.Current;
        }
    }
}
