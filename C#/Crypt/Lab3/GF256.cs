using System;
using System.Text;

namespace Lab3
{
    static public class GF256
    {
        static public string ToPolynomForm(byte item)
        {
            var result = new StringBuilder();

            for (uint i = 7; i >= 0; i--)
                if (Crypto.Lab1.BitOperation.GetBit(item, i) == 1)
                    result.Append($"x^{i}+");

            result.Replace("x^0", "1");
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        static public byte Mul(byte a, byte b)
        {
            byte aa = a, bb = b, r = 0, t;
            while (aa != 0)
            {
                if ((aa & 1) != 0)
                    r = (byte)(r ^ bb);
                t = (byte)(bb & 0x80);
                bb = (byte)(bb << 1);
                if (t != 0)
                    bb = (byte)(bb ^ 0x1b);
                aa = (byte)(aa >> 1);
            }
            return r;
        }

        static public byte Inverse(byte a)
        {
            return Pow(a, 254);
        }

        static private byte Pow(byte a, byte n)
        {
            byte result = a;

            while(n > 1)
            {
                n--;
                result = Mul(result, a);
            }

            return result;
        }


    }

}

