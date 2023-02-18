
namespace StdScoreViewerConfig
{
    partial class SemesterConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtStartTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkViewTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkImmediately = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkRank = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ckArithmeticAvg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ckWeightedAvg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.txtStartTime);
            this.groupPanel3.Controls.Add(this.chkViewTime);
            this.groupPanel3.Controls.Add(this.chkImmediately);
            this.groupPanel3.IsShadowEnabled = true;
            this.groupPanel3.Location = new System.Drawing.Point(12, 12);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(359, 153);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 17;
            this.groupPanel3.Text = "查詢時間設定";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(65, 75);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 33;
            this.labelX1.Text = "起始時間";
            // 
            // txtStartTime
            // 
            // 
            // 
            // 
            this.txtStartTime.Border.Class = "TextBoxBorder";
            this.txtStartTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartTime.Location = new System.Drawing.Point(131, 75);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(152, 25);
            this.txtStartTime.TabIndex = 32;
            this.txtStartTime.WatermarkText = "2022/12/09 16:00";
            this.txtStartTime.TextChanged += new System.EventHandler(this.txtStartTime_TextChanged);
            this.txtStartTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartTime_KeyDown);
            this.txtStartTime.Validated += new System.EventHandler(this.txtStartTime_Validated);
            // 
            // chkViewTime
            // 
            this.chkViewTime.AutoSize = true;
            // 
            // 
            // 
            this.chkViewTime.BackgroundStyle.Class = "";
            this.chkViewTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkViewTime.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkViewTime.Location = new System.Drawing.Point(44, 48);
            this.chkViewTime.Name = "chkViewTime";
            this.chkViewTime.Size = new System.Drawing.Size(107, 21);
            this.chkViewTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkViewTime.TabIndex = 31;
            this.chkViewTime.Text = "自訂查詢時間";
            // 
            // chkImmediately
            // 
            this.chkImmediately.AutoSize = true;
            // 
            // 
            // 
            this.chkImmediately.BackgroundStyle.Class = "";
            this.chkImmediately.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkImmediately.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkImmediately.Checked = true;
            this.chkImmediately.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImmediately.CheckValue = "Y";
            this.chkImmediately.Location = new System.Drawing.Point(44, 12);
            this.chkImmediately.Name = "chkImmediately";
            this.chkImmediately.Size = new System.Drawing.Size(80, 21);
            this.chkImmediately.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkImmediately.TabIndex = 29;
            this.chkImmediately.Text = "即時查詢";
            // 
            // chkRank
            // 
            this.chkRank.AutoSize = true;
            this.chkRank.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkRank.BackgroundStyle.Class = "";
            this.chkRank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkRank.Location = new System.Drawing.Point(291, 171);
            this.chkRank.Name = "chkRank";
            this.chkRank.Size = new System.Drawing.Size(80, 21);
            this.chkRank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkRank.TabIndex = 1;
            this.chkRank.Text = "顯示排名";
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(291, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(209, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 176);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(351, 80);
            this.labelX2.TabIndex = 35;
            this.labelX2.Text = "填寫說明：\r\n於起始時間輸入「月份/日期」並按下Enter，\r\n將自動轉為時間格式「西元年/月份/日期 00:00」，\r\n並可再調整輸入詳細時間。\r\n";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ckArithmeticAvg);
            this.groupPanel2.Controls.Add(this.ckWeightedAvg);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(12, -263);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(382, 72);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 34;
            this.groupPanel2.Text = "總計成績顯示";
            // 
            // ckArithmeticAvg
            // 
            this.ckArithmeticAvg.AutoSize = true;
            // 
            // 
            // 
            this.ckArithmeticAvg.BackgroundStyle.Class = "";
            this.ckArithmeticAvg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckArithmeticAvg.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.ckArithmeticAvg.Location = new System.Drawing.Point(203, 14);
            this.ckArithmeticAvg.Name = "ckArithmeticAvg";
            this.ckArithmeticAvg.Size = new System.Drawing.Size(80, 21);
            this.ckArithmeticAvg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckArithmeticAvg.TabIndex = 31;
            this.ckArithmeticAvg.Text = "算術平均";
            // 
            // ckWeightedAvg
            // 
            this.ckWeightedAvg.AutoSize = true;
            // 
            // 
            // 
            this.ckWeightedAvg.BackgroundStyle.Class = "";
            this.ckWeightedAvg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckWeightedAvg.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.ckWeightedAvg.Checked = true;
            this.ckWeightedAvg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckWeightedAvg.CheckValue = "Y";
            this.ckWeightedAvg.Location = new System.Drawing.Point(73, 14);
            this.ckWeightedAvg.Name = "ckWeightedAvg";
            this.ckWeightedAvg.Size = new System.Drawing.Size(80, 21);
            this.ckWeightedAvg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckWeightedAvg.TabIndex = 29;
            this.ckWeightedAvg.Text = "加權平均";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SemesterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 292);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkRank);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Name = "SemesterConfigForm";
            this.Text = "學生家長學期成績查詢設定";
            this.Load += new System.EventHandler(this.SemesterConfigForm_Load);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStartTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkViewTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkImmediately;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkRank;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckArithmeticAvg;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckWeightedAvg;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}