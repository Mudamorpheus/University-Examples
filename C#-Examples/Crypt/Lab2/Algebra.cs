using System;
using System.Collections.Generic;
using System.Numerics;

namespace Crypto.Lab2
{
    public static class Algebra
    {
        public static BigInteger[] GetPrimeNumbers(BigInteger m)
        {
            var result = new List<BigInteger>() { 2 };

            for (BigInteger i = 3; i < (m + 1); i += 2)
            {
                if ((i > 10) && (i % 10 == 5))
                    continue;

                bool f = false;
                for (var j = 0; j < result.Count; j++)
                {
                    if (result[j] * result[j] - 1 > i)
                    {
                        f = true;
                        result.Add(i);
                        break;
                    }
                    
                    if (i % result[j] == 0)
                    {
                        f = true;
                        break;
                    }
                }

                if (!f)
                    result.Add(i);
            }

            return result.ToArray();
        }

        public static BigInteger Euclid(BigInteger a, BigInteger b)
        {
            while (b > 0)
            {
                a %= b;
                (a, b) = (b, a);
            }

            return a;
        }

        public static BigInteger EuclidExBin(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            BigInteger g = 1;

            while (((a & 1) == 0) && ((b & 1) == 0))
            {
                a >>= 1;
                b >>= 1;
                g <<= 1;
            }

            BigInteger u = a;
            BigInteger v = b;
            BigInteger A = 1;
            BigInteger B = 0;
            BigInteger C = 0;
            BigInteger D = 1;

            while (u != 0)
            {
                while ((u & 1) == 0)
                {
                    u >>= 1;
                    if (((A & 1) == 0) && ((B & 1) == 0))
                    {
                        A >>= 1;
                        B >>= 1;
                    }
                    else
                    {
                        A = (A + b) >> 1;
                        B = (B - a) >> 1;
                    }
                }

                while ((v & 1) == 0)
                {
                    v >>= 1;
                    if (((C & 1) == 0) && ((D & 1) == 0))
                    {
                        C >>= 1;
                        D >>= 1;
                    }
                    else
                    {
                        C = (C + b) >> 1;
                        D = (D - a) >> 1;
                    }
                }

                if(u >= v)
                {
                    u -= v;
                    A -= C;
                    B -= D;
                }

                else
                {
                    v -= u;
                    C -= A;
                    D -= B;
                }
            }

            x = C;
            y = D;

            return g*v;
        }

        public static BigInteger Euler(int n)
        {
            int result = n;

            for (int i = 2; i * i <= n; ++i)
                if (n % i == 0)
                {
                    while (n % i == 0)
                        n /= i;
                    result -= result / i;
                }
            if (n > 1)
                result -= result / n;

            return result;
        }

        public static BigInteger PowMod(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger c = 1;
            while (b > 0)
            {
                if (b % 2 == 0)
                {
                    b /= 2;
                    a = a * a % n;
                }
                else
                {
                    b--;
                    c = c * a % n;
                }
            }
            return c;
        }

        public static BigInteger[] Factorization(BigInteger n)
        {
            var ans = new List<BigInteger>();

            for (BigInteger i = 2; i * i <= n; ++i)
                if (n % i == 0)
                {
                    while (n % i == 0)
                    {
                        n /= i;
                        ans.Add(i);
                    }
                }
            if (n > 1)
            {
                ans.Add(n);
            }

            return ans.ToArray();
        }

        public static BigInteger[] RDS(BigInteger m)
        {
            var result = new List<BigInteger>();

            for (BigInteger i = 2; i < m; i++)
                if (IsCoprime(m, i))
                    result.Add(i);

            return result.ToArray();
        }

        public static BigInteger MultInverse(BigInteger a, BigInteger m)
        {
            BigInteger x, y;
            BigInteger g = EuclidExBin(a, m, out x, out y);

            if (g != 1)
                throw new Exception("Not exist");

            x = (x % m + m) % m;

            return x;
        }

        private static bool IsCoprime(BigInteger a, BigInteger b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }

        
    }
}