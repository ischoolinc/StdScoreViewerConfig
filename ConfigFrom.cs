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
using System.IO;
using System.Xml;
using K12.Data;

namespace StdScoreViewerConfig
{
    public partial class ConfigFrom : BaseForm
    {

        public int dtstatue ;
        QueryHelper helper = new QueryHelper();

        /// <summary>
        /// 顯示算術平均
        /// </summary>
        static bool arithmeticAveSta;

        /// <summary>
        /// 顯示加權平均
        /// </summary>
        static bool weightedAveSta;


        /// <summary>
        /// 成績開放查詢設定
        /// 因2021/9 新增需求，新增一個「依據設定時間查看」的選項，而從bool改為string
        /// True=輸入截止後， False=即時查看，viewtime=依據設定時間查看
        /// </summary>
        //static bool enddataSet;
        static string viewOptionSet;

        /// <summary>
        /// 不顯示排名 (true:不顯示，false:顯示)
        /// 2022-11-13 Cynthia 因畫面調整，將原本不顯示排名的選項改為獨立的"顯示排名"，所以bool邏輯是反著
        /// </summary>
        static bool rankViewNull;

        /// <summary>
        /// 評量名稱
        /// </summary>
        private List<ExamRecord> _exams = Exam.SelectAll();

        /// <summary>
        /// 存在於XML中的評量名稱與時間對照
        /// </summary>
        Dictionary<string, string> examViewTimeMapping = new Dictionary<string, string>();

        /// <summary>
        /// 時間格式
        /// </summary>
        private const string DateTimeFormat = "yyyy/MM/dd HH:mm";

        public ConfigFrom()
        {
            InitializeComponent();

            List<int> cols = new List<int>() { 2 };
            Campus.Windows.DataGridViewImeDecorator dec = new Campus.Windows.DataGridViewImeDecorator(this.dataGridViewX1, cols);
        }

        private void ConfigFrom_Load(object sender, EventArgs e)
        {
            // 1. 先撈取所有的評量名稱，填入dgv
            foreach (ExamRecord exam in _exams)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewX1);
                row.Cells[0].Value = exam.ID;
                row.Cells[1].Value = exam.Name;

                dataGridViewX1.Rows.Add(row);
            }

            // 2. 從資料庫讀取資料
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
                //enddataSet = bool.Parse(nodes[0].SelectSingleNode("成績開放查詢設定").InnerText);

                //2021-9 
                viewOptionSet = nodes[0].SelectSingleNode("成績開放查詢設定").InnerText;

                // 3. 讀取XML中有存的評量ID及查詢起始時間，填入gdv中
                XmlNodeList xmlNodeList2 = doc.DocumentElement.SelectNodes("/Configurations/Exam/Item");

                foreach (XmlElement each in xmlNodeList2)
                {
                    string id = each.GetAttribute("id");
                    string viewtime = each.GetAttribute("viewtime");

                    if (!examViewTimeMapping.ContainsKey(id))
                    {
                        examViewTimeMapping.Add(id, viewtime);
                    }
                    foreach (DataGridViewRow item in dataGridViewX1.Rows)
                    {
                        string key = item.Cells[0].Value.ToString();
                        if (examViewTimeMapping.ContainsKey(key))
                        {
                            item.Cells[2].Value = examViewTimeMapping[key];
                        }
                    }
                }

                //如無資料,加入預設值
                if (table.Rows.Count == 0)
                {
                    this.ckArithmeticAvg.Checked = false;
                    this.ckWeightedAvg.Checked = true;
                    //this.ckNull.Checked = false;
                    this.chkRank.Checked = false;
                    this.ckEndTime.Checked = true;
                    dtstatue = 0;
                }
                else
                {
                    this.ckArithmeticAvg.Checked = arithmeticAveSta;
                    this.ckWeightedAvg.Checked = weightedAveSta;
                    //this.ckNull.Checked = rankViewNull;
                    this.chkRank.Checked = !rankViewNull;  //如果 XML 均不顯示排名為false，則畫面上"顯示排名" 要勾選

                    ///讀取XML中所存，顯示UI何者該check
                    if (viewOptionSet == "True")
                        this.ckEndTime.Checked = true;
                    else if (viewOptionSet == "False")
                        this.ckInstant.Checked = true;
                    else
                        this.ckViewTime.Checked = true;

                    dtstatue = 1;
                }

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Cyn 2021-9 檢查dataview有無錯誤資料
            foreach (DataGridViewRow dr in dataGridViewX1.Rows)
            {
                if (dr.ErrorText != "")
                {
                    MsgBox.Show("資料有誤，請修改。");
                    return;
                }

                foreach (DataGridViewCell cell in dr.Cells)
                {
                    if (cell.ErrorText != "")
                    {
                        MsgBox.Show("資料有誤，請修改。");
                        return;
                    }
                }
            }

            //轉換成Xml格式
            var aa = this.ckArithmeticAvg.Checked.ToString();
            var wa = this.ckWeightedAvg.Checked.ToString();
            //var nn = this.ckNull.Checked.ToString();
            var nn = (!this.chkRank.Checked).ToString(); //如果 XML 均不顯示排名為false，則畫面上"顯示排名" 要勾選
            //var ed = this.ckEndTime.Checked.ToString();

            string ed;
            if (this.ckEndTime.Checked)
                ed = "True";
            else if (this.ckInstant.Checked)
                ed = "False";
            else
                ed = "viewTime";

            ///將dgv上的評量查詢時間，拼湊成xml格式
            List<string> xmlList = new List<string>();

            foreach (DataGridViewRow rows in dataGridViewX1.Rows)
            {
                string id = rows.Cells[0].Value.ToString();
                string viewtime;
                if (rows.Cells[2].Value == null)
                    viewtime = "";
                else
                    viewtime = rows.Cells[2].Value.ToString();

                string xml = "<Item id=\"" + id + "\" viewtime=\"" + viewtime + "\" /> ";
                xmlList.Add(xml);
            }



            List<configItem> config = new List<configItem>()
	            {
		            new configItem() { 算術平均分數 = aa, 加權平均分數 = wa, 不顯示排名 = nn, 成績開放查詢設定 = ed },

	            };
	            var xmlTree = new XElement("Configurations",
	             from configItem in config
                 select new XElement("Configuration", 
				            new XElement("算數平均及排名", configItem.算術平均分數),
				            new XElement("加權平均及排名", configItem.加權平均分數),
                            new XElement("均不顯示排名", configItem.不顯示排名), // True: 不顯示排名，false:顯示排名
                            new XElement("成績開放查詢設定", configItem.成績開放查詢設定)
                            )

                 , new XElement("Exam", xmlList)

                 );



            if (dtstatue == 0)//如果資料庫沒有資料
            {
                string sql = @"INSERT INTO list(name, content)
VALUES('Web2成績查詢相關設定', '{0}')
RETURNING *
";
                sql = string.Format(sql
                            , xmlTree);
                sql = (sql.Replace("&lt;", "<")).Replace("&gt;", ">");
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
                sql = (sql.Replace("&lt;", "<")).Replace("&gt;", ">");
                DataTable dt = helper.Select(sql);
               

            }
            MessageBox.Show("設定完成。");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 輸入9/2 自動變換時間格式，格式同2021/09/06 00:00 評分樣板
        /// 檢查是否輸入時間格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var startTime = dataGridViewX1.Rows[e.RowIndex].Cells[2];

            DateTime dateTime;
            if (e.ColumnIndex == 2) //2 只能輸入時間
            {
                if (!string.IsNullOrWhiteSpace(startTime.EditedFormattedValue.ToString()))
                {
                    if (!DateTime.TryParse(startTime.EditedFormattedValue.ToString(), out dateTime))
                        dataGridViewX1.CurrentCell.ErrorText = "請輸入正確的時間格式，例如：2021/10/10 19:20";
                    else
                    {
                        DateTime? timeParse = DateTimeHelper.ParseGregorian(startTime.Value.ToString(), PaddingMethod.First);
                        startTime.Value = timeParse.Value.ToString(DateTimeFormat);

                        dataGridViewX1.CurrentCell.ErrorText = "";
                    }
                }
                else
                {
                    this.dataGridViewX1.CurrentCell.ErrorText = "";
                }
            }
        }

    }
}
