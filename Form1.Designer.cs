namespace tororo_gui
{
    partial class formTororo
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTororo));
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.timerContinue = new System.Windows.Forms.Timer(this.components);
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelBackColor = new System.Windows.Forms.Label();
            this.labelFontColor = new System.Windows.Forms.Label();
            this.checkTP = new System.Windows.Forms.CheckBox();
            this.buttonFont = new System.Windows.Forms.Button();
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadRecentLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            this.panelFunctions.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opf
            // 
            this.opf.RestoreDirectory = true;
            // 
            // timerContinue
            // 
            this.timerContinue.Interval = 2000;
            this.timerContinue.Tick += new System.EventHandler(this.timerContinue_Tick);
            // 
            // fontDialog
            // 
            this.fontDialog.Apply += new System.EventHandler(this.fontDialog_Apply);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(530, 334);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBoxOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOut.ForeColor = System.Drawing.Color.White;
            this.textBoxOut.Location = new System.Drawing.Point(0, 27);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOut.Size = new System.Drawing.Size(433, 231);
            this.textBoxOut.TabIndex = 1;
            this.textBoxOut.TextChanged += new System.EventHandler(this.textBoxOut_TextChanged);
            // 
            // labelBackColor
            // 
            this.labelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBackColor.Location = new System.Drawing.Point(238, 15);
            this.labelBackColor.Name = "labelBackColor";
            this.labelBackColor.Size = new System.Drawing.Size(20, 10);
            this.labelBackColor.TabIndex = 59;
            this.toolTip.SetToolTip(this.labelBackColor, "背景の色");
            this.labelBackColor.Click += new System.EventHandler(this.labelBackColor_Click);
            // 
            // labelFontColor
            // 
            this.labelFontColor.BackColor = System.Drawing.Color.White;
            this.labelFontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFontColor.Location = new System.Drawing.Point(238, 3);
            this.labelFontColor.Name = "labelFontColor";
            this.labelFontColor.Size = new System.Drawing.Size(20, 10);
            this.labelFontColor.TabIndex = 58;
            this.toolTip.SetToolTip(this.labelFontColor, "フォントの色");
            this.labelFontColor.Click += new System.EventHandler(this.labelFontColor_Click);
            // 
            // checkTP
            // 
            this.checkTP.AutoSize = true;
            this.checkTP.Location = new System.Drawing.Point(330, 6);
            this.checkTP.Name = "checkTP";
            this.checkTP.Size = new System.Drawing.Size(72, 16);
            this.checkTP.TabIndex = 61;
            this.checkTP.Text = "強力透過";
            this.toolTip.SetToolTip(this.checkTP, "透けすぎて困るの");
            this.checkTP.UseVisualStyleBackColor = true;
            this.checkTP.CheckedChanged += new System.EventHandler(this.checkTP_CheckedChanged);
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(217, 3);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(15, 23);
            this.buttonFont.TabIndex = 57;
            this.buttonFont.Text = "f";
            this.toolTip.SetToolTip(this.buttonFont, "フォントの変更");
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOpacity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numericUpDownOpacity.Location = new System.Drawing.Point(264, 4);
            this.numericUpDownOpacity.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(43, 21);
            this.numericUpDownOpacity.TabIndex = 61;
            this.numericUpDownOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.numericUpDownOpacity, "透け透け度");
            this.numericUpDownOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // panelFunctions
            // 
            this.panelFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFunctions.Controls.Add(this.toolStrip1);
            this.panelFunctions.Controls.Add(this.numericUpDownOpacity);
            this.panelFunctions.Controls.Add(this.labelBackColor);
            this.panelFunctions.Controls.Add(this.labelFontColor);
            this.panelFunctions.Controls.Add(this.checkTP);
            this.panelFunctions.Controls.Add(this.label2);
            this.panelFunctions.Controls.Add(this.buttonFont);
            this.panelFunctions.Location = new System.Drawing.Point(0, 0);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(433, 28);
            this.panelFunctions.TabIndex = 53;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonLoadRecentLog,
            this.toolStripButtonReload,
            this.toolStripButtonStop,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(433, 25);
            this.toolStrip1.TabIndex = 65;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "toolStripButtonOpen";
            this.toolStripButtonOpen.ToolTipText = "開く";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonLoadRecentLog
            // 
            this.toolStripButtonLoadRecentLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadRecentLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadRecentLog.Image")));
            this.toolStripButtonLoadRecentLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadRecentLog.Name = "toolStripButtonLoadRecentLog";
            this.toolStripButtonLoadRecentLog.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLoadRecentLog.Text = "最新の LotRO チャットログを開く";
            this.toolStripButtonLoadRecentLog.Click += new System.EventHandler(this.toolStripButtonLoadRecentLog_Click);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReload.Image")));
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReload.Text = "再読み込み";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.CheckOnClick = true;
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "停止";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator2,
            this.toolStripMenuItem4,
            this.toolStripComboBox1,
            this.toolStripSeparator3,
            this.toolStripMenuItem5});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "フォント...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "文字色...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "背景色...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem4.Text = "不透明度";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem5.Text = "強力透過";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripSeparator4,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "%";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Checked = true;
            this.toolStripMenuItem6.CheckOnClick = true;
            this.toolStripMenuItem6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(193, 22);
            this.toolStripMenuItem6.Text = "ミニモードを使う";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(244, 22);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(244, 22);
            this.toolStripMenuItem8.Text = "toolStripMenuItem8";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // formTororo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 258);
            this.Controls.Add(this.textBoxOut);
            this.Controls.Add(this.panelFunctions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formTororo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.formTororo_Deactivate);
            this.Activated += new System.EventHandler(this.formTororo_Activated);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.formTororoTest_DragDrop);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formTororo_FormClosed);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.formTororoTest_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            this.panelFunctions.ResumeLayout(false);
            this.panelFunctions.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.Timer timerContinue;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Label labelBackColor;
        private System.Windows.Forms.Label labelFontColor;
        private System.Windows.Forms.CheckBox checkTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadRecentLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

