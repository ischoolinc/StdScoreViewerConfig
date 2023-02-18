using FISCA.Data;
using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace StdScoreViewerConfig
{
    public partial class SemesterConfigForm : BaseForm
    {
        public int dtstatue;

        bool ShowRank;
        bool ShowScore;
        bool ShowDegree;

        /// <summary>
        /// 即時查詢
        /// </summary>
        bool Immediately;

        /// <summary>
        /// 查詢起始時間
        /// </summary>
        string ViewTime;

        /// <summary>
        /// 時間格式
        /// </summary>
        private const string DateTimeFormat = "yyyy/MM/dd HH:mm";

        public SemesterConfigForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SemesterConfigForm_Load(object sender, EventArgs e)
        {
            QueryHelper helper = new QueryHelper();
            DataTable table = helper.Select("SELECT * FROM list WHERE name='學期成績查詢設定'");

            foreach (DataRow row in table.Rows)
            {
                string content = row["content"] + "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                XmlNodeList xmlNodeList = doc.DocumentElement.SelectNodes("/Configurations/Configuration");
                ShowRank = bool.Parse(xmlNodeList[0].SelectSingleNode("ShowRank").InnerText);
                //ShowScore = bool.Parse(xmlNodeList[0].SelectSingleNode("ShowScore").InnerText);
                //ShowDegree = bool.Parse(xmlNodeList[0].SelectSingleNode("ShowDegree").InnerText);
                Immediately = bool.Parse(xmlNodeList[0].SelectSingleNode("Immediately").InnerText);
                ViewTime = xmlNodeList[0].SelectSingleNode("ViewTime").InnerText;


                //如無資料,加入預設值
                if (table.Rows.Count == 0)
                {
                    //即時查詢
                    this.chkImmediately.Checked = true;
                    ////顯示分數
                    //this.chkScore.Checked = true;
                    dtstatue = 0;
                }
                else
                {
                    this.chkImmediately.Checked = Immediately;
                    this.chkViewTime.Checked = !Immediately;
                    //this.chkScore.Checked = ShowScore;
                    this.chkRank.Checked = ShowRank;
                    //this.chkDegree.Checked = ShowDegree;
                    this.txtStartTime.Text = ViewTime;
                    dtstatue = 1;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkViewTime.Checked && txtStartTime.Text == "")
            {
                MessageBox.Show("請輸入起始時間。", "未儲存", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtStartTime.Text != "" && !DateTimeParseStart())
            {
                MessageBox.Show("請輸入正確日期時間格式。", "未儲存", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QueryHelper helper = new QueryHelper();

            XElement savedXML =
                new XElement("Configurations",
                new XElement("Configuration",
                new XElement("ShowRank", chkRank.Checked.ToString()),
                //new XElement("ShowScore", chkScore.Checked.ToString()),
                //new XElement("ShowDegree", chkDegree.Checked.ToString()),
                new XElement("Immediately", chkImmediately.Checked.ToString()),
                new XElement("ViewTime", txtStartTime.Text)
            )
                );


            if (dtstatue == 0)//如果資料庫沒有資料
            {
                string sql = @"INSERT INTO list(name, content)
VALUES('學期成績查詢設定', '{0}')
RETURNING *
";
                sql = string.Format(sql
                            , savedXML);
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
WHERE name = '學期成績查詢設定'
RETURNING *";
                sql = string.Format(sql
            , savedXML);
                sql = (sql.Replace("&lt;", "<")).Replace("&gt;", ">");
                DataTable dt = helper.Select(sql);

            }

            MessageBox.Show("設定完成。");
        }

        #region 處理textbox時間格式轉換
        private void txtStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtStartTime_Validated(object sender, EventArgs e)
        {
            if (txtStartTime.Text != "" && DateTimeParseStart())
            {
                DateTime? objStart = DateTimeHelper.ParseGregorian(txtStartTime.Text, PaddingMethod.First);
                txtStartTime.Text = objStart.Value.ToString(DateTimeFormat);
            }

            if (txtStartTime.Text == "")
                errorProvider1.Clear();
        }

        private bool DateTimeParseStart()
        {
            bool a = false;

            DateTime dt1;
            if (DateTime.TryParse(txtStartTime.Text, out dt1))
            {
                a = true;
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(txtStartTime, "請輸入正確日期時間格式。");
            }

            return a;
        }


        private void txtStartTime_TextChanged(object sender, EventArgs e)
        {
            if (txtStartTime.Text == "")
                errorProvider1.Clear();
        }

        #endregion
    }
}
