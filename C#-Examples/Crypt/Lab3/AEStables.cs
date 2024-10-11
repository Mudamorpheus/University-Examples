using System;
namespace Server.Lab3
{
    public class AEStables
    {
        public AEStables()
        {
            loadE(); loadL(); loadInv();
            loadS(); loadInvS(); loadPowX();
        }

        private byte[] E = new byte[256]; 
        private byte[] L = new byte[256]; 
        private byte[] S = new byte[256]; 
        private byte[] invS = new byte[256]; 
        private byte[] inv = new byte[256]; 
        private byte[] powX = new byte[15]; 

        
        public byte SBox(byte b)
        {
            return S[b & 0xff];
        }

        public byte invSBox(byte b)
        {
            return invS[b & 0xff];
        }

        public byte Rcon(int i)
        {
            return powX[i - 1];
        }

        
        public byte FFMul(byte a, byte b)
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
                aa = (byte)((aa & 0xff) >> 1);
            }
            return r;
        }

        
        private void loadE()
        {
            byte x = (byte)0x01;
            int index = 0;
            E[index++] = (byte)0x01;
            for (int i = 0; i < 255; i++)
            {
                byte y = FFMul(x, (byte)0x03);
                E[index++] = y;
                x = y;
            }
        }

        
        private void loadL()
        { 
            int index;
            for (int i = 0; i < 255; i++)
            {
                L[E[i] & 0xff] = (byte)i;
            }
        }

        
        private void loadS()
        {
            int index;
            for (int i = 0; i < 256; i++)
                S[i] = (byte)(subBytes((byte)(i & 0xff)) & 0xff);
        }

        
        private void loadInv()
        {
            int index;
            for (int i = 0; i < 256; i++)
                inv[i] = (byte)(FFInv((byte)(i & 0xff)) & 0xff);
        }

        
        private void loadInvS()
        {
            int index;
            for (int i = 0; i < 256; i++)
            {
                invS[S[i] & 0xff] = (byte)i;
            }
        }

        
        private void loadPowX()
        {
            int index;
            byte x = (byte)0x02;
            byte xp = x;
            powX[0] = 1; powX[1] = x;
            for (int i = 2; i < 15; i++)
            {
                xp = FFMul(xp, x);
                powX[i] = xp;
            }
        }

        
        public byte FFInv(byte b)
        {
            byte e = L[b & 0xff];
            return E[0xff - (e & 0xff)];
        }

        
        public int ithBit(byte b, int i)
        {
            int[] m = new int[]{ 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
            return (b & m[i]) >> i;
        }

        
        public int subBytes(byte b)
        {
            byte inB = b;
            int res = 0;
            if (b != 0) 
                b = (byte)(FFInv(b) & 0xff);
            byte c = (byte)0x63;
            for (int i = 0; i < 8; i++)
            {
                int temp = 0;
                temp = ithBit(b, i) ^ ithBit(b, (i + 4) % 8) ^ ithBit(b, (i + 5) % 8) ^
                        ithBit(b, (i + 6) % 8) ^ ithBit(b, (i + 7) % 8) ^ ithBit(c, i);
                res = res | (temp << i);
            }
            return res;
        }
    }
}
