using PKHeX.Core;
using System;

namespace WangPluginPkm.RNG.Methods
{
    internal static class ColoRNG
    {
        private const int shift = 16;
        private const int shift8 = 8;
        public static uint Next(uint seed) => XDRNG.Next(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {

            var O = XDRNG.Next(seed); // SID16
            var A = XDRNG.Next(O); // PID
            var B = XDRNG.Next(A); // PID
            var C = XDRNG.Next(B); // Held Item
            var D = XDRNG.Next(C); // Version
            var E = XDRNG.Next(D); // OT Gender
            const int TID16 = 40122;
            var SID16 = (ushort)(O >> 16);
            var pid1 = A >> 16;
            var pid2 = B >> 16;
            pk.TID16 = TID16;
            pk.SID16 = SID16;
            var pid = pid1 << 16 | pid2;
            if ((pid2 > 7 ? 0 : 1) != (pid1 ^ SID16 ^ TID16))
                pid ^= 0x80000000;
            pk.PID = pid;
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            pk.HeldItem = (int)(C >> 31) + 169;
            pk.Version = (int)(D >> 31) + 1;
            pk.OT_Gender = (int)(E >> 31);
            Span<int> ivs = stackalloc int[6];
            GetSequentialIVsUInt32(E, ivs);

            pk.SetIVs(ivs);
            if (!r.CheckIV(r, pk))
            {
                return false;
            }
            pk.Gender = pk.GetSaneGender();
            return true;
        }
        private static void GetIVsInt32(Span<int> result, uint r1, uint r2)
        {
            result[5] = (int)r2 >> 10 & 0x1F;
            result[4] = (int)r2 >> 5 & 0x1F;
            result[3] = (int)(r2 & 0x1F);
            result[2] = (int)r1 >> 10 & 0x1F;
            result[1] = (int)r1 >> 5 & 0x1F;
            result[0] = (int)(r1 & 0x1F);
        }
        internal static void GetSequentialIVsUInt32(uint seed, Span<int> IVs)
        {
            for (int i = 0; i < 6; i++)
            {
                seed = Next(seed);
                IVs[i] = (int)(seed >> 27);
            }
        }
        private static uint combineRNG(uint upper, uint lower, uint shift)
        {
            return (upper << (int)shift) + lower;
        }
        private static bool CheckShiny(uint pid, int TID16, int SID16, bool[] shiny)
        {
            var s = (uint)(TID16 ^ SID16) ^ pid >> 16 ^ pid & 0xFFFF;
            if (shiny[0])
                return true;
            else if (shiny[1] && s < 8)
                return true;
            else if (shiny[2] && s < 8 && s != 0)
                return true;
            else if (shiny[3] && s == 0)
                return true;
            else if (shiny[4] && s == 1)
                return true;
            else
                return false;
        }
    }
}