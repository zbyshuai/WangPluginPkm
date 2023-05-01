﻿using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class RSE
    {
        public static List<PKM> RSESets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Groudon, (int)GameVersion.R);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Kyogre, (int)GameVersion.S);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Rayquaza, (int)GameVersion.E);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 3;
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
