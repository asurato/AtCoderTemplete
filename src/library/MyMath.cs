namespace Library
{
    class MyMath
    {
        public static long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        public static long Sqrt(long n)
        {
            if (n < 0) return 0;
            long a = 0, tmp = 0, b = 0;
            for (int i = 62; i >= 0; i -= 2)
            {
                tmp = (b << 1) + 1 <= (n >> i) ? 1 : 0;
                a = a << 1 | tmp;
                n -= (((b << 1) + 1) * tmp) << i;
                b = (b << 1) + tmp + tmp;
            }
            return a;
        }

        public static long Nck(int n, int k)
        {
            if (k == 0) return 1;
            if (n == 0) return 0;
            return n * Nck(n - 1, k - 1) / k;
        }
    }
}
