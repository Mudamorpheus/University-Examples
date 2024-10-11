using ModeWork;

namespace Server.Lab3
{
    public class AES: ICoderBlok
    {
        private int Nb = 4; 
        private int Nk; 
        private int Nr; 
        private int wCount; 
        private AEStables tab; 
        private byte[] w; 

        public int Size => 16;

        public AES(byte[] key, int NkIn)
        {
            Nk = NkIn; 
            Nr = Nk + 6; 
            tab = new AEStables(); 
            w = new byte[4 * Nb * (Nr + 1)]; 
            KeyExpansion(key, w); 
        }

        public byte[] EncodeBlok(byte[] input)
        {
            var output = new byte[input.Length];

            wCount = 0; 
            var state = new byte[4][]; 
            for (int i = 0; i < 4; i++)
                state[i] = new byte[Nb];

            copy(state, input); 
            AddRoundKey(state); 
            for (int round = 1; round < Nr; round++)
            {
                SubBytes(state); 
                ShiftRows(state); 
                MixColumns(state); 
                AddRoundKey(state); 
            }
            SubBytes(state); 
            ShiftRows(state); 
            AddRoundKey(state); 
            copy(output, state);

            return output;
        }

        public byte[] DecodeBlok(byte[] input)
        {
            var output = new byte[input.Length];

            wCount = 4 * Nb * (Nr + 1); 
            byte[][] state = new byte[4][]; 
            for (int i = 0; i < 4; i++)
                state[i] = new byte[Nb];

            copy(state, input); 
            InvAddRoundKey(state); 
            for (int round = Nr - 1; round >= 1; round--)
            {
                InvShiftRows(state); 
                InvSubBytes(state); 
                InvAddRoundKey(state); 
                InvMixColumns(state); 
            }
            InvShiftRows(state); 
            InvSubBytes(state); 
            InvAddRoundKey(state); 
            copy(output, state);

            return output;
        }

        private void KeyExpansion(byte[] key, byte[] w)
        {
            byte[] temp = new byte[4];
            
            int j = 0;
            while (j < 4 * Nk)
            {
                w[j] = key[j++];
            }
            
            int i;
            while (j < 4 * Nb * (Nr + 1))
            {
                i = j / 4; 
                           
                for (int iTemp = 0; iTemp < 4; iTemp++)
                    temp[iTemp] = w[j - 4 + iTemp];
                if (i % Nk == 0)
                {
                    byte ttemp, tRcon;
                    byte oldtemp0 = temp[0];
                    for (int iTemp = 0; iTemp < 4; iTemp++)
                    {
                        if (iTemp == 3) ttemp = oldtemp0;
                        else ttemp = temp[iTemp + 1];
                        if (iTemp == 0) tRcon = tab.Rcon(i / Nk);
                        else tRcon = 0;
                        temp[iTemp] = (byte)(tab.SBox(ttemp) ^ tRcon);
                    }
                }
                else if (Nk > 6 && (i % Nk) == 4)
                {
                    for (int iTemp = 0; iTemp < 4; iTemp++)
                        temp[iTemp] = tab.SBox(temp[iTemp]);
                }
                for (int iTemp = 0; iTemp < 4; iTemp++)
                    w[j + iTemp] = (byte)(w[j - 4 * Nk + iTemp] ^ temp[iTemp]);
                j = j + 4;
            }
        }

        private void SubBytes(byte[][] state)
        {
            for (int row = 0; row < 4; row++)
                for (int col = 0; col < Nb; col++)
                    state[row][col] = tab.SBox(state[row][col]);
        }

        private void ShiftRows(byte[][] state)
        {
            byte[] t = new byte[4];
            for (int r = 1; r < 4; r++)
            {
                for (int c = 0; c < Nb; c++)
                    t[c] = state[r][(c + r) % Nb];
                for (int c = 0; c < Nb; c++)
                    state[r][c] = t[c];
            }
        }

        private void MixColumns(byte[][] s)
        {
            int[] sp = new int[4];
            byte b02 = (byte)0x02, b03 = (byte)0x03;
            for (int c = 0; c < 4; c++)
            {
                sp[0] = tab.FFMul(b02, s[0][c]) ^ tab.FFMul(b03, s[1][c]) ^
                        s[2][c] ^ s[3][c];
                sp[1] = s[0][c] ^ tab.FFMul(b02, s[1][c]) ^
                        tab.FFMul(b03, s[2][c]) ^ s[3][c];
                sp[2] = s[0][c] ^ s[1][c] ^
                        tab.FFMul(b02, s[2][c]) ^ tab.FFMul(b03, s[3][c]);
                sp[3] = tab.FFMul(b03, s[0][c]) ^ s[1][c] ^
                        s[2][c] ^ tab.FFMul(b02, s[3][c]);
                for (int i = 0; i < 4; i++) s[i][c] = (byte)(sp[i]);
            }
        }

        
        private void AddRoundKey(byte[][] state)
        {
            for (int c = 0; c < Nb; c++)
                for (int r = 0; r < 4; r++)
                    state[r][c] = (byte)(state[r][c] ^ w[wCount++]);
        }

        private void InvSubBytes(byte[][] state)
        {
            for (int row = 0; row < 4; row++)
                for (int col = 0; col < Nb; col++)
                    state[row][col] = tab.invSBox(state[row][col]);
        }

        
        private void InvShiftRows(byte[][] state)
        {
            byte[] t = new byte[4];
            for (int r = 1; r < 4; r++)
            {
                for (int c = 0; c < Nb; c++)
                    t[(c + r) % Nb] = state[r][c];
                for (int c = 0; c < Nb; c++)
                    state[r][c] = t[c];
            }
        }

        
        private void InvMixColumns(byte[][] s)
        {
            int[] sp = new int[4];
            byte b0b = (byte)0x0b; byte b0d = (byte)0x0d;
            byte b09 = (byte)0x09; byte b0e = (byte)0x0e;
            for (int c = 0; c < 4; c++)
            {
                sp[0] = tab.FFMul(b0e, s[0][c]) ^ tab.FFMul(b0b, s[1][c]) ^
                        tab.FFMul(b0d, s[2][c]) ^ tab.FFMul(b09, s[3][c]);
                sp[1] = tab.FFMul(b09, s[0][c]) ^ tab.FFMul(b0e, s[1][c]) ^
                        tab.FFMul(b0b, s[2][c]) ^ tab.FFMul(b0d, s[3][c]);
                sp[2] = tab.FFMul(b0d, s[0][c]) ^ tab.FFMul(b09, s[1][c]) ^
                        tab.FFMul(b0e, s[2][c]) ^ tab.FFMul(b0b, s[3][c]);
                sp[3] = tab.FFMul(b0b, s[0][c]) ^ tab.FFMul(b0d, s[1][c]) ^
                        tab.FFMul(b09, s[2][c]) ^ tab.FFMul(b0e, s[3][c]);
                for (int i = 0; i < 4; i++) s[i][c] = (byte)(sp[i]);
            }
        }

        
        private void InvAddRoundKey(byte[][] state)
        {
            for (int c = Nb - 1; c >= 0; c--)
                for (int r = 3; r >= 0; r--)
                    state[r][c] = (byte)(state[r][c] ^ w[--wCount]);
        }

        private void copy(byte[][] state, byte[] input)
        {
            int inLoc = 0;
            for (int c = 0; c < Nb; c++)
                for (int r = 0; r < 4; r++)
                    state[r][c] = input[inLoc++];
        }

        
        private void copy(byte[] output, byte[][] state)
        {
            int outLoc = 0;
            for (int c = 0; c < Nb; c++)
                for (int r = 0; r < 4; r++)
                output[outLoc++] = state[r][c];
        }
    }
}
