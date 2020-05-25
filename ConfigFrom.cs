using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using System.Xml.Linq;
using FISCA.Data;
using StdScoreViewerConfig.Model;
using FISCA.Presentation;
using K12.Data;
using System.IO;
using System.Xml;

namespace StdScoreViewerConfig
{
    public partial class ConfigFrom : Form
    {

        public int dtstatue ;
        QueryHelper helper = new QueryHelper();
        static bool arithmeticAveSta;
        static bool weightedAveSta;
        static bool enddataSet;
        static bool rankViewNull;



        public ConfigFrom()
        {
            InitializeComponent();
        }

        private void ConfigFrom_Load(object sender, EventArgs e)
        {
            //先從資料庫讀取資料
            DataTable table = helper.Select("SELECT * FROM list WHERE name='Web2成績查詢相關設定'");

            Console.WriteLine(table);

            //取得回傳資料第一筆Row的物件
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row);
                string content = row["content"] + "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Configurations/Configuration");

                arithmeticAveSta = bool.Parse(nodes[0].SelectSingleNode("算數平均及排名").InnerText);
                weightedAveSta = bool.Parse(nodes[0].SelectSingleNode("加權平均及排名").InnerText);
                rankViewNull = bool.Parse(nodes[0].SelectSingleNode("均不顯示排名").InnerText);
                enddataSet = bool.Parse(nodes[0].SelectSingleNode("成績開放查詢設定").InnerText);

                //如無資料,加入預設值
                if (table.Rows.Count == 0)
                {
                    this.radioBtnArithmeticAve.Checked = false;
                    this.radioBtnWeightedAve.Checked = false;
                    this.radioBtnNull.Checked = false;
                    this.enddata.Checked = true;
                    dtstatue = 0;


                }
                else
                {
                    this.radioBtnArithmeticAve.Checked = arithmeticAveSta;
                    this.radioBtnWeightedAve.Checked = weightedAveSta;
                    this.radioBtnNull.Checked = rankViewNull;

                    //因成績開放查詢設定，僅寫入單一值判斷，惟因畫面需求加入此判斷
                    if (enddataSet == false)
                    {
                        this.radioBtnInstant.Checked = true;
                    }
                    else
                    {
                        this.enddata.Checked = enddataSet;
                    }

                    dtstatue = 1;
                }


            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //轉換成Xml格式
            var aa = this.radioBtnArithmeticAve.Checked.ToString();
            var wa = this.radioBtnWeightedAve.Checked.ToString();
            var nn = this.radioBtnNull.Checked.ToString();
            var ed = this.enddata.Checked.ToString();

            List<configItem> config = new List<configItem>()
	            {
		            new configItem() { 算數平均及排名 = aa, 加權平均及排名 = wa, 均不顯示排名 = nn, 成績開放查詢設定 = ed },

	            };
	            var xmlTree = new XElement("Configurations",
	             from configItem in config
                 select new XElement("Configuration", 
				            new XElement("算數平均及排名", configItem.算數平均及排名),
				            new XElement("加權平均及排名", configItem.加權平均及排名),
                            new XElement("均不顯示排名", configItem.均不顯示排名),
                            new XElement("成績開放查詢設定", configItem.成績開放查詢設定)));



            if (dtstatue == 0)//如果資料庫沒有資料
            {
                string sql = @"INSERT INTO list(name, content)
VALUES('Web2成績查詢相關設定', '{0}')
RETURNING *
";
                sql = string.Format(sql
                            , xmlTree);
                DataTable dt = helper.Select(sql);
                dtstatue = 1;

            }
            else //如果資料庫已經有資資料
            {
                string sql = @"UPDATE 
list
SET  
content = '{0}'
WHERE name = 'Web2成績查詢相關設定'
RETURNING *";
                sql = string.Format(sql
            , xmlTree);
                DataTable dt = helper.Select(sql);
               

            }
            MessageBox.Show("已完成成績查詢設定");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void RadioBtnArithmeticAve_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioBtnWeightedAve_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LabelX4_Click(object sender, EventArgs e)
        {

        }
    }

}
