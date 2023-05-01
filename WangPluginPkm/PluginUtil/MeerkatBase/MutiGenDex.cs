﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
using WangPluginPkm.PluginUtil.AchieveBase;
using WangPluginPkm.GUI;
using WangPluginPkm.RNG.Methods;
using System.Windows.Forms;

namespace WangPluginPkm.PluginUtil.MeerkatBase
{
    internal class MutiGenDex
    {
        public static List<PKM> SetGen1(ISaveFileProvider SAV, IPKMView Editor,bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            _ = new List<PKM>();
            SAV1 sa = new();
            List<PKM> PKL = sa.GenerateLivingDex(false, false, false, false).ToList();
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    PKL[i].ClearNickname();
                   if (i == 150 && shiny)
                    {
                        PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mew, (int)GameVersion.E);
                        PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                        PKL[i].OT_Name = "Meerk";
                        PKL[i].AbilityNumber = 1;
                    }
                    else if(i!=150)
                    {
                        PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    }
                    if(shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                   
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen2(ISaveFileProvider SAV, bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            _ = new List<PKM>();
            SAV2 sa = new();
            List<PKM> PKL = sa.GenerateLivingDex(false, false, false, false).ToList();
            for(int i=0;i<151; i++)
            {
                PKL.RemoveAt(0);
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    if (PKL[i].Version==40)
                    {
                        PKL[i].Version = 39;
                    }
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }

                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen3(ISaveFileProvider SAV,  IPKMView Editor,bool shiny)
        {
           if(SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
           
            var PKL= new List<PKM>();
            for (int i = 252; i < 387; i++)
            {
               PKL.Add( SearchDatabase.SearchPKM(SAV,Editor,(ushort)i,(int)GameVersion.E));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out _);
                    switch(i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 12:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 14:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == 0)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 15:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == 0)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 16:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val = WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val == 1)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo3(PKL[i]);
                            break;
                        case 17:
                            while (true)
                            {
                                PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)265, (int)GameVersion.E);
                                var val=WurmpleUtil.GetWurmpleEvoVal(PKL[i].EncryptionConstant);
                                if (val==1)
                                    break;
                            }
                            PKL[i] = AchieveFunc.evo4(PKL[i]);
                            break;
                        case 19:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E,0,false,0,0,0,3);
                            break;
                        case 22:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E, 0, false, 0, 0, 0, 3);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)273, (int)GameVersion.E, 0, false, 0, 0, 0, 3);
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 25:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 27:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 29:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].Gender = 2;
                            break;
                        case 42:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 45:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 46:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)298, (int)GameVersion.E,0,true);
                            break;
                        case 49:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 53:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 54:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 55:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)307, (int)GameVersion.R);
                            break;
                        case 56:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)307, (int)GameVersion.R);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 59:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)311, (int)GameVersion.E, 0, false, 0, 0, 0, 12); ;
                            break;
                        case 63:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)315, (int)GameVersion.R); ;
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 80;
                            break;
                        case 71:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 74:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 78:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 80:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 82:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 83:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)335, (int)GameVersion.R); ;
                            break;
                        case 85:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)335, (int)GameVersion.R); ;
                            break;
                        case 87:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)337, (int)GameVersion.S); ;
                            break;
                        case 90:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 92:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 94:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 96:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 98:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            if (PKL[i] is IContestStats a)
                            {
                                a.CNT_Beauty = 255;
                            }
                            break;
                        case 102:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 104:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 110:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 112:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 113:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 115:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 116:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 120:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 121:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 123:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 124:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 133:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, (ushort)385, (int)GameVersion.R);
                            if(shiny)
                            {
                                PKL[i].PID = 1177749629;
                                PKL[i].EncryptionConstant = 1177749629;
                                PKL[i].Nature = 4;
                                PKL[i].IV_HP = 21;
                                PKL[i].IV_ATK = 31;
                                PKL[i].IV_DEF = 31;
                                PKL[i].IV_DEF = 31;
                                PKL[i].IV_SPA = 18;
                                PKL[i].IV_SPD = 24;
                                PKL[i].IV_SPE = 19;
                            }
                            break;
                    }
                    
                  
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen4(ISaveFileProvider SAV, IPKMView Editor,bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            _ = new List<PKM>();
            SAV4Pt sa = new();
            List<PKM> PKL = sa.GenerateLivingDex(false, false, false, false).ToList();
            for (int i = 0; i < 386; i++)
            {
                PKL.RemoveAt(0);
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    if (PKL[i].Species==490)
                    {
                        PKL[i].Language = 1;
                        PKL[i].ClearNickname();
                    }
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }

                }
            }
            
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen5(ISaveFileProvider SAV, IPKMView Editor,bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            CheckRules r = new()
            {
                Shiny = PkmCondition.ShinyType.Shiny,
            };
            PKM pk;
            var PKL = new List<PKM>();
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 494, (int)GameVersion.W2));
            for (int i = 495; i < 637; i++)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.W, 0, true);
                pk.CurrentLevel = 5;
                PKL.Add(pk);
            }
            for (int i = 637; i < 650; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.W2));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    switch (i)
                    {
                        case 2:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 3:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 6:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 9:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 11:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 14:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                          
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                      
                            break;
                        case 22:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            
                            break;
                        case 24:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                         
                            break;
                        case 26:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 27:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 522, (int)GameVersion.B);
                            break;
                        case 29:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 31:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 42:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 47:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 48:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);

                            break;
                        case 51:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);

                            break;
                        case 53:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].RefreshAbility(2);
                            break;
                        case 55:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].RefreshAbility(2);
                            break;
                        case 58:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 59:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 61:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 64:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 66:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 71:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 73:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 75:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 77:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 79:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 80:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 574, (int)GameVersion.B,0,true);
                            break;
                        case 81:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 82:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 84:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 85:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 87:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 89:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 90:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 92:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 95:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 97:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 99:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 102:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 104:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 106:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 107:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 109:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 110:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 112:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 114:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 115:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 117:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 118:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 120:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 123:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 126:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 129:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 131:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 134:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 136:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            break;
                        case 140:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 141:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;

                    }
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                        switch(i)
                        {
                            case 143:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 144:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 145:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                            case 146:
                                {
                                    pk = PKL[i];
                                    var seed = WangRandUtil.NextRand(0);
                                    while (true)
                                    {
                                        if (Gen5Wild.GenPkm(ref pk, seed, r))
                                        {
                                            PKL[i] = pk;
                                            PKL[i].AbilityNumber = 1;
                                            PKL[i].EncryptionConstant = PKL[i].PID;
                                            break;
                                        }
                                        else
                                        {
                                            seed++;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen6(ISaveFileProvider SAV, IPKMView Editor,bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 650; i < 722; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.X));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 12:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 20:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 25:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 28:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 31:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 33:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 35:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 37:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 39:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 40:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 690, (int)GameVersion.Y);
                            break;
                        case 41:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 691, (int)GameVersion.Y);
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 43:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 45:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 47:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                       case 49:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 50:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 133, (int)GameVersion.Y,0,true);
                            PKL[i].CurrentLevel = 50;
                            PKL[i].Species = 700;
                            PKL[i].RefreshAbility(0);
                       
                            break;
                        case 55:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 50;
                            break;
                        case 56:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 59:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 61:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 63:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 65:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            break;
                        case 67:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 717, (int)GameVersion.Y);
                            break;
                    }


                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);

                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
               
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetGen7(ISaveFileProvider SAV, IPKMView Editor,bool shiny)
        {
            if (SAV.SAV is SAV7 s)
            {
                s.ConsoleRegion = 1;
                s.Country = 49;
            }
            var PKL = new List<PKM>();
            for (int i = 722; i < 808; i++)
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, (int)GameVersion.US));
            }
            if (PKL.Count != 0)
            {
                for (int i = 0; i < PKL.Count; i++)
                {
                    PKL[i] = EntityConverter.ConvertToType(PKL[i], SAV.SAV.PKMType, out var r2);
                    switch (i)
                    {
                        case 1:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 2:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 4:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 5:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 7:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 8:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 10:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 11:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 13:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 15:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 16:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 18:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 21:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 23:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 26:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 40;
                            break;
                        case 28:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 30:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 32:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 34:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 36:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].Gender = 1;
                            break;
                        case 39:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 761, (int)GameVersion.SN,0,true);
                            break;
                        case 41:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 46:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 48:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 51:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 58:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 780, (int)GameVersion.UM);
                            break;
                        case 61:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            break;
                        case 62:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            break;
                        case 68:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 60;
                            PKL[i].Move1 = 150;
                            PKL[i].Move2 = 0;
                            PKL[i].Move3 = 0;
                            PKL[i].Move4 = 0;
                            PKL[i].HealPP();
                            PKL[i].RefreshAbility(1);
                            break;
                        case 69:
                            PKL[i] = AchieveFunc.evo2(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(1);
                            break;
                        case 70:
                            PKL[i] = AchieveFunc.evo3(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(1);
                            break;
                        case 73:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 795, (int)GameVersion.UM);
                            break;
                        case 75:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 797, (int)GameVersion.UM);
                            break;
                        case 82:
                            PKL[i] = AchieveFunc.evo1(PKL[i]);
                            PKL[i].CurrentLevel = 70;
                            PKL[i].RefreshAbility(0);
                            break;
                        case 83:
                            PKL[i] = SearchDatabase.SearchPKM(SAV, Editor, 805, (int)GameVersion.UM);
                            break;

                    }
                    PKL[i].ClearNickname();
                    PKL[i] = AchieveFunc.fun(PKL[i],SAV);
                    if (shiny)
                    {
                        PKL[i] = ShinyMakerUI.ShinyFunctionPlus(PKL[i]);
                    }
                }
            }
            SAV.ReloadSlots();
            return PKL;
        }
        public static List<PKM> SetAll(ISaveFileProvider SAV, IPKMView Editor, bool shiny)
        {
            List<PKM> PKL = SetGen1(SAV, Editor, shiny).Concat(SetGen2(SAV, shiny)).
                                  Concat(SetGen3(SAV, Editor, shiny)).Concat(SetGen4(SAV, Editor, shiny)).
                                  Concat(SetGen5(SAV, Editor, shiny)).Concat(SetGen6(SAV, Editor, shiny)).
                                  Concat(SetGen7(SAV, Editor, shiny)).ToList();
            return PKL;
        }
    }
}
