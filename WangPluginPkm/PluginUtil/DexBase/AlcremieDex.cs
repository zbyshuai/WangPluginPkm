using PKHeX.Core;
using System.Collections.Generic;
using PKHeX.Core.AutoMod;

namespace WangPluginPkm.PluginUtil.DexBase

{
    internal class AlcremieDex
    {
        private static PKM AlcremiePK(ISaveFileProvider sav, PKM pk)
        {
            // 宝可梦最佳配置
            pk.CurrentLevel = 100;
            pk.Nature = 15;
            pk.StatNature = 15;
            pk.IV_ATK = 31;
            pk.IV_DEF = 31;
            pk.IV_HP = 31;
            pk.IV_SPA = 31;
            pk.IV_SPD = 31;
            pk.IV_SPE = 31;
            pk.EV_HP = 2;

            // 训练家信息
            pk.Language = sav.SAV.Language;
            pk.TrainerTID7 = sav.SAV.TrainerTID7;
            pk.TrainerSID7 = sav.SAV.TrainerSID7;
            pk.OT_Gender = sav.SAV.Gender;
            pk.OT_Name = sav.SAV.OT;

            // 删除杂项
            RibbonApplicator.RemoveAllValidRibbons(pk);
            pk.ClearNickname();

            return pk;
        }

        public static List<PKM> AlcremieSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 868, 45, 0, true);
                                pk.CurrentLevel = 50;
                                pk.Species = 869;
                                pk.Form = (byte)i;
                                ((PK8)pk).FormArgument = (byte)j;
                                // 生成模板配置
                                pk = AlcremiePK(SAV, pk);
                                // 传入列表
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;              
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 868, 50, 0, true);
                                pk.Species = 869;
                                pk.Form = (byte)i;
                                ((PK9)pk).FormArgument = (byte)j;
                                // 生成模板配置
                                pk = AlcremiePK(SAV, pk);
                                // 传入列表
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return PKL;
        }
    }
}
