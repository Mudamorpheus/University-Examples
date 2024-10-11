using System.Numerics;
using System;

namespace Crypto.Lab2
{
    public class RSA 
    {
        private BigInteger _n, _phi, _e, _d;
        //public  byte[] Mul(byte[] u, byte[] v)
        //{
        //    byte[] result = new byte[u.Length + v.Length];
        //    uBigInteger k, t, b;
        //    BigInteger i, j;

        //    for (i = 0; i < u.Length; i++)
        //        result[i] = 0;

        //    for (j = 0; j < v.Length; j++)
        //    {
        //        k = 0;
        //        for (i = 0; i < u.Length; i++)
        //        {
        //            t = (uBigInteger)(u[i] * v[j] + result[i + j] + k);
        //            result[i + j] = (byte)t;
        //            k = t >> 8;
        //        }
        //        result[j + u.Length] = (byte)k;
        //    }

        //    return result;
        //}

        public (BigInteger, BigInteger) GetCloseKey()
        {
            if (_d == null || _n == null) throw new NullReferenceException();

            return (_d, _n);
        }

        public byte[] Encode(byte[] message)
        {
            var p = Gen();
            var q = Gen();
            Console.WriteLine(p);
            Console.WriteLine(q);
            _n = p * q;
            _phi = (p - 1) * (q - 1);

            var E = new int[] { 3, 5, 17, 257, 65537 };
            _e = E[new Random().Next() % E.Length];

            _d = Algebra.MultInverse(_e, _phi);

            var c = Algebra.PowMod(new BigInteger(message), _e, _n);
                
            return c.ToByteArray();
        }

        public byte[] Decode(byte[] code, BigInteger d, BigInteger n)
        {
            var m = Algebra.PowMod(new BigInteger(code), d, n);

            return m.ToByteArray();
        }


        private BigInteger Gen()
        { 
            var rnd = new Random();
            var bytex = new byte[128];
            for (BigInteger i = 0; i < bytex.Length; i++)
                rnd.NextBytes(bytex);

            var x = BigInteger.Abs(new BigInteger(bytex));
            while (!MillerRabinPrimalityTest(x, 7))
                x++;

            return x;
        }

        private  bool MillerRabinPrimalityTest(BigInteger p, BigInteger s)
        {
            if (p == 2)
                return true;
            if ((p & 1) == 0)
                return false;

            var p1 = p - 1;
            var u = 0;
            var r = p1;

            while ((r & 1) == 0)
            {
                r >>= 1;
                u++;
            }

            for(BigInteger i = 0; i < s; i++)
            {
                BigInteger a = new Random().Next() % ((BigInteger)p - 2) + 2;
                if (Witness(a, r, p, p1, u))
                    return false;
            }

            return true;
        }

        private  bool Witness(BigInteger a, BigInteger r, BigInteger p, BigInteger p1, BigInteger u)
        {
            var z = Algebra.PowMod(a, r, p);
            if (z == 1)
                return false;

            for (var i = 0; i < u; i++)
            {
                z = Algebra.PowMod(a, (1 << i) * r, p);
                if (z == p1)
                    return false;
            }

            return true;
        }
    }
}
