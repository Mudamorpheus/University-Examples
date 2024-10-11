MASK8 = 0xFF
MASK32 = 0xFFFFFFFF
MASK64 = 0xFFFFFFFFFFFFFFFF
MASK128 = 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
MASK192 = 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
MASK256 = 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
C1 = 0xA09E667F3BCC908B
C2 = 0xB67AE8584CAA73B2
C3 = 0xC6EF372FE94F82BE
C4 = 0x54FF53A5F1D36F1C
C5 = 0x10E527FADE682D1D
C6 = 0xB05688C2B3E6C1FD

SBOX1 = [
    112, 130, 44, 236, 179, 39, 192, 229, 228, 133, 87, 53, 234, 12, 174, 65,
    35, 239, 107, 147, 69, 25, 165, 33, 237, 14, 79, 78, 29, 101, 146, 189,
    134, 184, 175, 143, 124, 235, 31, 206, 62, 48, 220, 95, 94, 197, 11, 26,
    166, 225, 57, 202, 213, 71, 93, 61, 217, 1, 90, 214, 81, 86, 108, 77,
    139, 13, 154, 102, 251, 204, 176, 45, 116, 18, 43, 32, 240, 177, 132, 153,
    223, 76, 203, 194, 52, 126, 118, 5, 109, 183, 169, 49, 209, 23, 4, 215,
    20, 88, 58, 97, 222, 27, 17, 28, 50, 15, 156, 22, 83, 24, 242, 34,
    254, 68, 207, 178, 195, 181, 122, 145, 36, 8, 232, 168, 96, 252, 105, 80,
    170, 208, 160, 125, 161, 137, 98, 151, 84, 91, 30, 149, 224, 255, 100, 210,
    16, 196, 0, 72, 163, 247, 117, 219, 138, 3, 230, 218, 9, 63, 221, 148,
    135, 92, 131, 2, 205, 74, 144, 51, 115, 103, 246, 243, 157, 127, 191, 226,
    82, 155, 216, 38, 200, 55, 198, 59, 129, 150, 111, 75, 19, 190, 99, 46,
    233, 121, 167, 140, 159, 110, 188, 142, 41, 245, 249, 182, 47, 253, 180, 89,
    120, 152, 6, 106, 231, 70, 113, 186, 212, 37, 171, 66, 136, 162, 141, 250,
    114, 7, 185, 85, 248, 238, 172, 10, 54, 73, 42, 104, 60, 56, 241, 164,
    64, 40, 211, 123, 187, 201, 67, 193, 21, 227, 173, 244, 119, 199, 128, 158
]
progress = 0


class Camellia:
    def __init__(self, key):  # Ключ в виде байтов
        self._key_size = len(key) * 8
        if self._key_size not in [128, 192, 256]:
            raise ValueError("Invalid Camellia key size. Key must be exactly 128/192/256 bits long.")
        self._key = int.from_bytes(key, byteorder='little')

    def encode_block(self, block):
        block = int.from_bytes(block, byteorder='little')

        # Ключ разбивается на 2 128-битные части KL и KR
        KL, KR = self._split_key(self._key)

        # Вычисляем 128-битные числа KA и KB. Переменные D1 и D2 64-битные.
        D1 = (KL ^ KR) >> 64
        D2 = (KL ^ KR) & MASK64
        D2 = D2 ^ self.F(D1, C1)
        D1 = D1 ^ self.F(D2, C2)
        D1 = D1 ^ (KL >> 64)
        D2 = D2 ^ (KL & MASK64)
        D2 = D2 ^ self.F(D1, C3)
        D1 = D1 ^ self.F(D2, C4)
        KA = (D1 << 64) | D2
        D1 = (KA ^ KR) >> 64
        D2 = (KA ^ KR) & MASK64
        D2 = D2 ^ self.F(D1, C5)
        D1 = D1 ^ self.F(D2, C6)
        KB = (D1 << 64) | D2

        # Вычисляем вспомогательные 64-битные ключи kw1, ..., kw4, k1, ..., k24, ke1, ..., ke6
        # в зависимости от размера ключа
        if self._key_size == 128:
            kw1 = self.shift(KL, 0, 128) >> 64
            kw2 = self.shift(KL, 0, 128) & MASK64
            k1 = self.shift(KA, 0, 128) >> 64
            k2 = self.shift(KA, 0, 128) & MASK64
            k3 = self.shift(KL, 15, 128) >> 64
            k4 = self.shift(KL, 15, 128) & MASK64
            k5 = self.shift(KA, 15, 128) >> 64
            k6 = self.shift(KA, 15, 128) & MASK64
            ke1 = self.shift(KA, 30, 128) >> 64
            ke2 = self.shift(KA, 30, 128) & MASK64
            k7 = self.shift(KL, 45, 128) >> 64
            k8 = self.shift(KL, 45, 128) & MASK64
            k9 = self.shift(KA, 45, 128) >> 64
            k10 = self.shift(KL, 60, 128) & MASK64
            k11 = self.shift(KA, 60, 128) >> 64
            k12 = self.shift(KA, 60, 128) & MASK64
            ke3 = self.shift(KL, 77, 128) >> 64
            ke4 = self.shift(KL, 77, 128) & MASK64
            k13 = self.shift(KL, 94, 128) >> 64
            k14 = self.shift(KL, 94, 128) & MASK64
            k15 = self.shift(KA, 94, 128) >> 64
            k16 = self.shift(KA, 94, 128) & MASK64
            k17 = self.shift(KL, 111, 128) >> 64
            k18 = self.shift(KL, 111, 128) & MASK64
            kw3 = self.shift(KA, 111, 128) >> 64
            kw4 = self.shift(KA, 111, 128) & MASK64
        else:
            kw1 = self.shift(KL, 0, 128) >> 64
            kw2 = self.shift(KL, 0, 128) & MASK64
            k1 = self.shift(KB, 0, 128) >> 64
            k2 = self.shift(KB, 0, 128) & MASK64
            k3 = self.shift(KR, 15, 128) >> 64
            k4 = self.shift(KR, 15, 128) & MASK64
            k5 = self.shift(KA, 15, 128) >> 64
            k6 = self.shift(KA, 15, 128) & MASK64
            ke1 = self.shift(KR, 30, 128) >> 64
            ke2 = self.shift(KR, 30, 128) & MASK64
            k7 = self.shift(KB, 30, 128) >> 64
            k8 = self.shift(KB, 30, 128) & MASK64
            k9 = self.shift(KL, 45, 128) >> 64
            k10 = self.shift(KL, 45, 128) & MASK64
            k11 = self.shift(KA, 45, 128) >> 64
            k12 = self.shift(KA, 45, 128) & MASK64
            ke3 = self.shift(KL, 60, 128) >> 64
            ke4 = self.shift(KL, 60, 128) & MASK64
            k13 = self.shift(KR, 60, 128) >> 64
            k14 = self.shift(KR, 60, 128) & MASK64
            k15 = self.shift(KB, 60, 128) >> 64
            k16 = self.shift(KB, 60, 128) & MASK64
            k17 = self.shift(KL, 77, 128) >> 64
            k18 = self.shift(KL, 77, 128) & MASK64
            ke5 = self.shift(KA, 77, 128) >> 64
            ke6 = self.shift(KA, 77, 128) & MASK64
            k19 = self.shift(KR, 94, 128) >> 64
            k20 = self.shift(KR, 94, 128) & MASK64
            k21 = self.shift(KA, 94, 128) >> 64
            k22 = self.shift(KA, 94, 128) & MASK64
            k23 = self.shift(KL, 111, 128) >> 64
            k24 = self.shift(KL, 111, 128) & MASK64
            kw3 = self.shift(KB, 111, 128) >> 64
            kw4 = self.shift(KB, 111, 128) & MASK64

        # Шифрование происходит по схеме Фейстеля с 18 этапами для 128 - битного ключа и 24 этапами для 192 - и
        # 256 - битных ключей. Каждые 6 этапов применяются функции FL и FLINV.
        if self._key_size == 128:
            D1 = block >> 64
            D2 = block & MASK64
            D1 = D1 ^ kw1  # Предварительное забеливание
            D2 = D2 ^ kw2
            D2 = D2 ^ self.F(D1, k1)
            D1 = D1 ^ self.F(D2, k2)
            D2 = D2 ^ self.F(D1, k3)
            D1 = D1 ^ self.F(D2, k4)
            D2 = D2 ^ self.F(D1, k5)
            D1 = D1 ^ self.F(D2, k6)
            D1 = self.FL(D1, ke1)  # FL
            D2 = self.FLINV(D2, ke2)  # FLINV
            D2 = D2 ^ self.F(D1, k7)
            D1 = D1 ^ self.F(D2, k8)
            D2 = D2 ^ self.F(D1, k9)
            D1 = D1 ^ self.F(D2, k10)
            D2 = D2 ^ self.F(D1, k11)
            D1 = D1 ^ self.F(D2, k12)
            D1 = self.FL(D1, ke3)  # FL
            D2 = self.FLINV(D2, ke4)  # FLINV
            D2 = D2 ^ self.F(D1, k13)
            D1 = D1 ^ self.F(D2, k14)
            D2 = D2 ^ self.F(D1, k15)
            D1 = D1 ^ self.F(D2, k16)
            D2 = D2 ^ self.F(D1, k17)
            D1 = D1 ^ self.F(D2, k18)
            D2 = D2 ^ kw3  # Финальное забеливание
            D1 = D1 ^ kw4
            C = (D2 << 64) | D1
        else:
            D1 = block >> 64  # Шифруемое сообщение делится на две 64-битные части
            D2 = block & MASK64
            D1 = D1 ^ kw1  # Предварительное забеливание
            D2 = D2 ^ kw2
            D2 = D2 ^ self.F(D1, k1)
            D1 = D1 ^ self.F(D2, k2)
            D2 = D2 ^ self.F(D1, k3)
            D1 = D1 ^ self.F(D2, k4)
            D2 = D2 ^ self.F(D1, k5)
            D1 = D1 ^ self.F(D2, k6)
            D1 = self.FL(D1, ke1)  # FL
            D2 = self.FLINV(D2, ke2)  # FLINV
            D2 = D2 ^ self.F(D1, k7)
            D1 = D1 ^ self.F(D2, k8)
            D2 = D2 ^ self.F(D1, k9)
            D1 = D1 ^ self.F(D2, k10)
            D2 = D2 ^ self.F(D1, k11)
            D1 = D1 ^ self.F(D2, k12)
            D1 = self.FL(D1, ke3)  # FL
            D2 = self.FLINV(D2, ke4)  # FLINV
            D2 = D2 ^ self.F(D1, k13)
            D1 = D1 ^ self.F(D2, k14)
            D2 = D2 ^ self.F(D1, k15)
            D1 = D1 ^ self.F(D2, k16)
            D2 = D2 ^ self.F(D1, k17)
            D1 = D1 ^ self.F(D2, k18)
            D1 = self.FL(D1, ke5)  # FL
            D2 = self.FLINV(D2, ke6)  # FLINV
            D2 = D2 ^ self.F(D1, k19)
            D1 = D1 ^ self.F(D2, k20)
            D2 = D2 ^ self.F(D1, k21)
            D1 = D1 ^ self.F(D2, k22)
            D2 = D2 ^ self.F(D1, k23)
            D1 = D1 ^ self.F(D2, k24)
            D2 = D2 ^ kw3  # Финальное забеливание
            D1 = D1 ^ kw4
            C = (D2 << 64) | D1

        return C.to_bytes(16, byteorder='little')

    def decode_block(self, block):
        block = int.from_bytes(block, byteorder='little')
        KL, KR = self._split_key(self._key)

        D1 = (KL ^ KR) >> 64
        D2 = (KL ^ KR) & MASK64
        D2 = D2 ^ self.F(D1, C1)
        D1 = D1 ^ self.F(D2, C2)
        D1 = D1 ^ (KL >> 64)
        D2 = D2 ^ (KL & MASK64)
        D2 = D2 ^ self.F(D1, C3)
        D1 = D1 ^ self.F(D2, C4)
        KA = (D1 << 64) | D2
        D1 = (KA ^ KR) >> 64
        D2 = (KA ^ KR) & MASK64
        D2 = D2 ^ self.F(D1, C5)
        D1 = D1 ^ self.F(D2, C6)
        KB = (D1 << 64) | D2

        if self._key_size == 128:
            kw1 = self.shift(KL, 0, 128) >> 64
            kw2 = self.shift(KL, 0, 128) & MASK64
            k1 = self.shift(KA, 0, 128) >> 64
            k2 = self.shift(KA, 0, 128) & MASK64
            k3 = self.shift(KL, 15, 128) >> 64
            k4 = self.shift(KL, 15, 128) & MASK64
            k5 = self.shift(KA, 15, 128) >> 64
            k6 = self.shift(KA, 15, 128) & MASK64
            ke1 = self.shift(KA, 30, 128) >> 64
            ke2 = self.shift(KA, 30, 128) & MASK64
            k7 = self.shift(KL, 45, 128) >> 64
            k8 = self.shift(KL, 45, 128) & MASK64
            k9 = self.shift(KA, 45, 128) >> 64
            k10 = self.shift(KL, 60, 128) & MASK64
            k11 = self.shift(KA, 60, 128) >> 64
            k12 = self.shift(KA, 60, 128) & MASK64
            ke3 = self.shift(KL, 77, 128) >> 64
            ke4 = self.shift(KL, 77, 128) & MASK64
            k13 = self.shift(KL, 94, 128) >> 64
            k14 = self.shift(KL, 94, 128) & MASK64
            k15 = self.shift(KA, 94, 128) >> 64
            k16 = self.shift(KA, 94, 128) & MASK64
            k17 = self.shift(KL, 111, 128) >> 64
            k18 = self.shift(KL, 111, 128) & MASK64
            kw3 = self.shift(KA, 111, 128) >> 64
            kw4 = self.shift(KA, 111, 128) & MASK64

            # swap
            kw1, kw3 = kw3, kw1
            kw2, kw4 = kw4, kw2
            k1, k18 = k18, k1
            k2, k17 = k17, k2
            k3, k16 = k16, k3
            k4, k15 = k15, k4
            k5, k14 = k14, k5
            k6, k13 = k13, k6
            k7, k12 = k12, k7
            k8, k11 = k11, k8
            k9, k10 = k10, k9
            ke1, ke4 = ke4, ke1
            ke2, ke3 = ke3, ke2
        else:
            kw1 = self.shift(KL, 0, 128) >> 64
            kw2 = self.shift(KL, 0, 128) & MASK64
            k1 = self.shift(KB, 0, 128) >> 64
            k2 = self.shift(KB, 0, 128) & MASK64
            k3 = self.shift(KR, 15, 128) >> 64
            k4 = self.shift(KR, 15, 128) & MASK64
            k5 = self.shift(KA, 15, 128) >> 64
            k6 = self.shift(KA, 15, 128) & MASK64
            ke1 = self.shift(KR, 30, 128) >> 64
            ke2 = self.shift(KR, 30, 128) & MASK64
            k7 = self.shift(KB, 30, 128) >> 64
            k8 = self.shift(KB, 30, 128) & MASK64
            k9 = self.shift(KL, 45, 128) >> 64
            k10 = self.shift(KL, 45, 128) & MASK64
            k11 = self.shift(KA, 45, 128) >> 64
            k12 = self.shift(KA, 45, 128) & MASK64
            ke3 = self.shift(KL, 60, 128) >> 64
            ke4 = self.shift(KL, 60, 128) & MASK64
            k13 = self.shift(KR, 60, 128) >> 64
            k14 = self.shift(KR, 60, 128) & MASK64
            k15 = self.shift(KB, 60, 128) >> 64
            k16 = self.shift(KB, 60, 128) & MASK64
            k17 = self.shift(KL, 77, 128) >> 64
            k18 = self.shift(KL, 77, 128) & MASK64
            ke5 = self.shift(KA, 77, 128) >> 64
            ke6 = self.shift(KA, 77, 128) & MASK64
            k19 = self.shift(KR, 94, 128) >> 64
            k20 = self.shift(KR, 94, 128) & MASK64
            k21 = self.shift(KA, 94, 128) >> 64
            k22 = self.shift(KA, 94, 128) & MASK64
            k23 = self.shift(KL, 111, 128) >> 64
            k24 = self.shift(KL, 111, 128) & MASK64
            kw3 = self.shift(KB, 111, 128) >> 64
            kw4 = self.shift(KB, 111, 128) & MASK64

            # swap
            kw1, kw3 = kw3, kw1
            kw2, kw4 = kw4, kw2
            k1, k24 = k24, k1
            k2, k23 = k23, k2
            k3, k22 = k22, k3
            k4, k21 = k21, k4
            k5, k20 = k20, k5
            k6, k19 = k19, k6
            k7, k18 = k18, k7
            k8, k17 = k17, k8
            k9, k16 = k16, k9
            k10, k15 = k15, k10
            k11, k14 = k14, k11
            k12, k13 = k13, k12
            ke1, ke6 = ke6, ke1
            ke2, ke5 = ke5, ke2
            ke3, ke4 = ke4, ke3

        if self._key_size == 128:
            D1 = block >> 64  # Шифруемое сообщение делится на две 64 - битные части
            D2 = block & MASK64
            D1 = D1 ^ kw1  # Предварительное забеливание
            D2 = D2 ^ kw2
            D2 = D2 ^ self.F(D1, k1)
            D1 = D1 ^ self.F(D2, k2)
            D2 = D2 ^ self.F(D1, k3)
            D1 = D1 ^ self.F(D2, k4)
            D2 = D2 ^ self.F(D1, k5)
            D1 = D1 ^ self.F(D2, k6)
            D1 = self.FL(D1, ke1)  # FL
            D2 = self.FLINV(D2, ke2)  # FLINV
            D2 = D2 ^ self.F(D1, k7)
            D1 = D1 ^ self.F(D2, k8)
            D2 = D2 ^ self.F(D1, k9)
            D1 = D1 ^ self.F(D2, k10)
            D2 = D2 ^ self.F(D1, k11)
            D1 = D1 ^ self.F(D2, k12)
            D1 = self.FL(D1, ke3)  # FL
            D2 = self.FLINV(D2, ke4)  # FLINV
            D2 = D2 ^ self.F(D1, k13)
            D1 = D1 ^ self.F(D2, k14)
            D2 = D2 ^ self.F(D1, k15)
            D1 = D1 ^ self.F(D2, k16)
            D2 = D2 ^ self.F(D1, k17)
            D1 = D1 ^ self.F(D2, k18)
            D2 = D2 ^ kw3  # Финальное забеливание
            D1 = D1 ^ kw4
            C = (D2 << 64) | D1
        else:
            D1 = block >> 64  # Шифруемое сообщение делится на две 64-битные части
            D2 = block & MASK64
            D1 = D1 ^ kw1  # Предварительное забеливание
            D2 = D2 ^ kw2
            D2 = D2 ^ self.F(D1, k1)
            D1 = D1 ^ self.F(D2, k2)
            D2 = D2 ^ self.F(D1, k3)
            D1 = D1 ^ self.F(D2, k4)
            D2 = D2 ^ self.F(D1, k5)
            D1 = D1 ^ self.F(D2, k6)
            D1 = self.FL(D1, ke1)  # FL
            D2 = self.FLINV(D2, ke2)  # FLINV
            D2 = D2 ^ self.F(D1, k7)
            D1 = D1 ^ self.F(D2, k8)
            D2 = D2 ^ self.F(D1, k9)
            D1 = D1 ^ self.F(D2, k10)
            D2 = D2 ^ self.F(D1, k11)
            D1 = D1 ^ self.F(D2, k12)
            D1 = self.FL(D1, ke3)  # FL
            D2 = self.FLINV(D2, ke4)  # FLINV
            D2 = D2 ^ self.F(D1, k13)
            D1 = D1 ^ self.F(D2, k14)
            D2 = D2 ^ self.F(D1, k15)
            D1 = D1 ^ self.F(D2, k16)
            D2 = D2 ^ self.F(D1, k17)
            D1 = D1 ^ self.F(D2, k18)
            D1 = self.FL(D1, ke5)  # FL
            D2 = self.FLINV(D2, ke6)  # FLINV
            D2 = D2 ^ self.F(D1, k19)
            D1 = D1 ^ self.F(D2, k20)
            D2 = D2 ^ self.F(D1, k21)
            D1 = D1 ^ self.F(D2, k22)
            D2 = D2 ^ self.F(D1, k23)
            D1 = D1 ^ self.F(D2, k24)
            D2 = D2 ^ kw3  # Финальное забеливание
            D1 = D1 ^ kw4
            C = (D2 << 64) | D1

        return C.to_bytes(16, byteorder='little')

    def _split_key(self, key):
        if self._key_size == 128:
            return key, 0
        elif self._key_size == 192:
            return key >> 64, ((key & MASK64) << 64) | (~(key & MASK64))
        else:
            return key >> 128, key & MASK128

    def shift(self, num, shift, num_size):
        shift %= num_size

        return ((num << shift) | (num >> (num_size - shift))) & ((1 << num_size) - 1)

    # Вспомогательные функции
    def F(self, F_IN, KE):
        """
        Функция F использует 16 8 - битных переменных t1, ..., t8, y1, ..., y8 и 1 64 - битную переменную.
        :param F_IN: данные (64 бит)
        :param KE: ключ (64 бит)
        :return: 64-битное число
        """
        x = F_IN ^ KE
        t1 = x >> 56
        t2 = (x >> 48) & MASK8
        t3 = (x >> 40) & MASK8
        t4 = (x >> 32) & MASK8
        t5 = (x >> 24) & MASK8
        t6 = (x >> 16) & MASK8
        t7 = (x >> 8) & MASK8
        t8 = x & MASK8
        t1 = SBOX1[t1]
        t2 = self.shift(SBOX1[t2], 1, 8)
        t3 = self.shift(SBOX1[t3], 7, 8)
        t4 = SBOX1[self.shift(t4, 1, 8)]
        t5 = self.shift(SBOX1[t5], 1, 8)
        t6 = self.shift(SBOX1[t6], 7, 8)
        t7 = SBOX1[self.shift(t7, 1, 8)]
        t8 = SBOX1[t8]
        y1 = t1 ^ t3 ^ t4 ^ t6 ^ t7 ^ t8
        y2 = t1 ^ t2 ^ t4 ^ t5 ^ t7 ^ t8
        y3 = t1 ^ t2 ^ t3 ^ t5 ^ t6 ^ t8
        y4 = t2 ^ t3 ^ t4 ^ t5 ^ t6 ^ t7
        y5 = t1 ^ t2 ^ t6 ^ t7 ^ t8
        y6 = t2 ^ t3 ^ t5 ^ t7 ^ t8
        y7 = t3 ^ t4 ^ t5 ^ t6 ^ t8
        y8 = t1 ^ t4 ^ t5 ^ t6 ^ t7
        F_OUT = (y1 << 56) | (y2 << 48) | (y3 << 40) | (y4 << 32) | (y5 << 24) | (y6 << 16) | (y7 << 8) | y8

        return F_OUT

    def FL(self, FL_IN, KE):
        """
        Функция FL использует 4 32 - битные переменные x1, x2, k1, k2.
        :param FL_IN: данные (64 бит)
        :param KE: ключ (64 бит)
        :return: 64-битное число
        """
        x1 = FL_IN >> 32
        x2 = FL_IN & MASK32
        k1 = KE >> 32
        k2 = KE & MASK32
        x2 = x2 ^ self.shift(x1 & k1, 1, 32)
        x1 = x1 ^ (x2 | k2)
        FL_OUT = (x1 << 32) | x2

        return FL_OUT

    def FLINV(self, FLINV_IN, KE):
        """
        Функция FLINV - обратная к FL
        """
        y1 = FLINV_IN >> 32
        y2 = FLINV_IN & MASK32
        k1 = KE >> 32
        k2 = KE & MASK32
        y1 = y1 ^ (y2 | k2)
        y2 = y2 ^ self.shift(y1 & k1, 1, 32)
        FLINV_OUT = (y1 << 32) | y2

        return FLINV_OUT


class ECB:
    def __init__(self, camellia):
        self.camellia = camellia
        self.block_size = 16

    def encode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]

        for block in blocks:
            yield self.camellia.encode_block(block)

    def decode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]

        for block in blocks:
            yield self.camellia.decode_block(block)


class CBC:
    def __init__(self, camellia, c0):
        self.camellia = camellia
        self.c0 = c0
        self.block_size = 16

    def encode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]
        prev = self.c0

        for block in blocks:
            prev = self.camellia.encode_block(xor_bytes(block, prev, self.block_size))
            yield prev

    def decode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]
        prev = self.c0

        for block in blocks:
            yield xor_bytes(self.camellia.decode_block(block), prev, self.block_size)
            prev = block


class OFB:
    def __init__(self, camellia, c0):
        self.camellia = camellia
        self.c0 = c0
        self.block_size = 16

    def encode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]
        prev = self.c0

        for block in blocks:
            prev = self.camellia.encode_block(prev)
            yield xor_bytes(prev, block, self.block_size)

    def decode(self, b_arr):
        return self.encode(b_arr)


class CFB:
    def __init__(self, camellia, c0):
        self.camellia = camellia
        self.c0 = c0
        self.block_size = 16

    def encode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]
        prev = self.c0

        for block in blocks:
            prev = xor_bytes(self.camellia.encode_block(prev), block, self.block_size)
            yield prev

    def decode(self, b_arr):
        blocks = [b_arr[i: i + self.block_size] for i in range(0, len(b_arr), self.block_size)]
        prev = self.c0

        for block in blocks:
            yield xor_bytes(self.camellia.encode_block(prev), block, self.block_size)
            prev = block


def xor_bytes(a, b, size):
    return (int.from_bytes(a, byteorder='little') ^ int.from_bytes(b, byteorder='little'))\
        .to_bytes(size, byteorder='little')
