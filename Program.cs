using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;
using System.Windows.Forms;


namespace StdScoreViewerConfig
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            #region 評量成績查詢設定
            {
                RoleAclSource.Instance["教務作業"]["功能按鈕"].Add(new RibbonFeature("AED2F99E-3947-4A07-BC54-019F63783A40", "學生家長評量成績查詢設定"));
                MotherForm.RibbonBarItems["教務作業", "基本設定"]["設定"]["學生家長評量成績查詢設定"].Enable = UserAcl.Current["AED2F99E-3947-4A07-BC54-019F63783A40"].Executable;
                MotherForm.RibbonBarItems["教務作業", "基本設定"]["設定"]["學生家長評量成績查詢設定"].Click += delegate
                {
                    ConfigFrom configForm = new ConfigFrom();
                    configForm.ShowDialog();
                };
            }
            #endregion




        }

    }
    }
