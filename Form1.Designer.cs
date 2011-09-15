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
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.rTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new tororo_gui.ToolStripEx();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadRecentLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFontSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripCheckMinimode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCheckScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCheckTP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TipOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNumericUpDownOpacity = new ToolStripNumericUpDown();
            this.TipInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNumericUpDownInterval = new ToolStripNumericUpDown();
            this.toolStrip.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "ミニモードを使う";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem2.Text = "強力透過";
            this.toolStripMenuItem2.ToolTipText = "透けすぎて困るの";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem3.Text = "更新間隔(ミリ秒)";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rTextBoxOut
            // 
            this.rTextBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTextBoxOut.BackColor = System.Drawing.Color.Black;
            this.rTextBoxOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTextBoxOut.ForeColor = System.Drawing.Color.White;
            this.rTextBoxOut.Location = new System.Drawing.Point(0, 25);
            this.rTextBoxOut.Name = "rTextBoxOut";
            this.rTextBoxOut.ReadOnly = true;
            this.rTextBoxOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rTextBoxOut.Size = new System.Drawing.Size(411, 266);
            this.rTextBoxOut.TabIndex = 67;
            this.rTextBoxOut.Text = "";
            // 
            // toolStrip
            // 
            this.toolStrip.ClickThrough = true;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonLoadRecentLog,
            this.toolStripSeparator1,
            this.toolStripButtonReload,
            this.toolStripButtonStop,
            this.toolStripSeparator4,
            this.toolStripButtonFontSettings,
            this.toolStripDropDownButtonSettings});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(159, 25);
            this.toolStrip.TabIndex = 66;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "開く";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "停止";
            this.toolStripButtonStop.CheckedChanged += new System.EventHandler(this.toolStripButtonStop_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFontSettings
            // 
            this.toolStripButtonFontSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFontSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFontSettings.Image")));
            this.toolStripButtonFontSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFontSettings.Name = "toolStripButtonFontSettings";
            this.toolStripButtonFontSettings.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFontSettings.Text = "フォントと色の設定...";
            this.toolStripButtonFontSettings.Click += new System.EventHandler(this.toolStripButtonFontSettings_Click);
            // 
            // toolStripDropDownButtonSettings
            // 
            this.toolStripDropDownButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCheckMinimode,
            this.toolStripCheckScroll,
            this.toolStripCheckTP,
            this.toolStripSeparator2,
            this.TipOpacity,
            this.toolStripNumericUpDownOpacity,
            this.TipInterval,
            this.toolStripNumericUpDownInterval});
            this.toolStripDropDownButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSettings.Image")));
            this.toolStripDropDownButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSettings.Name = "toolStripDropDownButtonSettings";
            this.toolStripDropDownButtonSettings.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonSettings.Text = "設定";
            this.toolStripDropDownButtonSettings.ToolTipText = "設定";
            // 
            // toolStripCheckMinimode
            // 
            this.toolStripCheckMinimode.Checked = true;
            this.toolStripCheckMinimode.CheckOnClick = true;
            this.toolStripCheckMinimode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripCheckMinimode.Name = "toolStripCheckMinimode";
            this.toolStripCheckMinimode.Size = new System.Drawing.Size(232, 22);
            this.toolStripCheckMinimode.Text = "ミニモードを使う";
            // 
            // toolStripCheckScroll
            // 
            this.toolStripCheckScroll.Checked = true;
            this.toolStripCheckScroll.CheckOnClick = true;
            this.toolStripCheckScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripCheckScroll.Name = "toolStripCheckScroll";
            this.toolStripCheckScroll.Size = new System.Drawing.Size(232, 22);
            this.toolStripCheckScroll.Text = "随時最新行にスクロールする";
            // 
            // toolStripCheckTP
            // 
            this.toolStripCheckTP.CheckOnClick = true;
            this.toolStripCheckTP.Name = "toolStripCheckTP";
            this.toolStripCheckTP.Size = new System.Drawing.Size(232, 22);
            this.toolStripCheckTP.Text = "強力透過";
            this.toolStripCheckTP.ToolTipText = "透けすぎて困るの";
            this.toolStripCheckTP.CheckedChanged += new System.EventHandler(this.toolStripCheckTP_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // TipOpacity
            // 
            this.TipOpacity.Enabled = false;
            this.TipOpacity.Name = "TipOpacity";
            this.TipOpacity.Size = new System.Drawing.Size(232, 22);
            this.TipOpacity.Text = "不透明度(%)";
            // 
            // toolStripNumericUpDownOpacity
            // 
            this.toolStripNumericUpDownOpacity.Name = "toolStripNumericUpDownOpacity";
            this.toolStripNumericUpDownOpacity.Size = new System.Drawing.Size(45, 25);
            this.toolStripNumericUpDownOpacity.Text = "50";
            this.toolStripNumericUpDownOpacity.TextChanged += new System.EventHandler(this.toolStripNumericUpDownOpacity_ValueChanged);
            // 
            // TipInterval
            // 
            this.TipInterval.Enabled = false;
            this.TipInterval.Name = "TipInterval";
            this.TipInterval.Size = new System.Drawing.Size(232, 22);
            this.TipInterval.Text = "更新間隔(ミリ秒)";
            // 
            // toolStripNumericUpDownInterval
            // 
            this.toolStripNumericUpDownInterval.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripNumericUpDownInterval.Name = "toolStripNumericUpDownInterval";
            this.toolStripNumericUpDownInterval.Size = new System.Drawing.Size(45, 25);
            this.toolStripNumericUpDownInterval.Text = "100";
            this.toolStripNumericUpDownInterval.TextChanged += new System.EventHandler(this.toolStripNumericUpDownInterval_ValueChanged);
            // 
            // formTororo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 300);
            this.Controls.Add(this.rTextBoxOut);
            this.Controls.Add(this.toolStrip);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::tororo_gui.Properties.Settings.Default, "formTororoLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::tororo_gui.Properties.Settings.Default.formTororoLocation;
            this.Name = "formTororo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.toolTip.SetToolTip(this, "設定");
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.formTororo_Activated);
            this.Deactivate += new System.EventHandler(this.formTororo_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formTororo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formTororo_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.formTororoTest_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.formTororoTest_DragEnter);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.Timer timerContinue;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadRecentLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFontSettings;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripCheckMinimode;
        private System.Windows.Forms.ToolStripMenuItem toolStripCheckTP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem TipOpacity;
        private ToolStripNumericUpDown toolStripNumericUpDownOpacity;
        private System.Windows.Forms.ToolStripMenuItem TipInterval;
        private ToolStripNumericUpDown toolStripNumericUpDownInterval;
        private System.Windows.Forms.RichTextBox rTextBoxOut;
        private ToolStripEx toolStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripCheckScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

