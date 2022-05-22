﻿namespace WangPlugin
{
    internal class Version
    {
        public static bool Gen3Flag(int Version)
        {
            if (Version == 1|| Version == 2 || Version == 3 || Version == 4 || Version == 5)
                return true;
            else
                return false;
        }
        public static bool Gen4Flag (int Version)
        {
            if (Version is 10 or 11 or 12 or 7 or 8)
                return true;
            else
                return false;
        }
        public static bool Gen5Flag (int Version)
        {
            if (Version is 20 or 21 or 22 or 23)
                return true;
            else
                return false;
        }
        public static bool Gen6Flag(int Version)
        {
            if (Version is 24 or 25 or 26 or 27)
                return true;
            else
                return false;
        }
        public static bool Gen7Flag(int Version)
        {
            if (Version is 30 or 31 or 32 or 33)
                return true;
            else
                return false;
        }
        public static bool Gen8SWSHFlag(int Version)
        {
            if (Version is 44 or 45)
                return true;
            else
                return false;
        }
        public static bool Gen8BDSPFlag(int Version)
        {
            if (Version is 48 or 49)
                return true;
            else
                return false;
        }
        public static bool Gen8PLAFlag(int Version)
        {
            if (Version is 47)
                return true;
            else
                return false;
        }
        public static bool Gen1VCFlag(int Version)
        {
            if (Version is 35 or 36 or 37 or 38)
                return true;
            else
                return false;
        }
        public static bool Gen2VCFlag(int Version)
        {
            if (Version is 39 or 40 or 41 )
                return true;
            else
                return false;
        }
        public static bool CXDFlag(int Version)
        {
            if (Version is 15)
                return true;
            else
                return false;
        }
    }
}
