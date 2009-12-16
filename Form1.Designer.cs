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
            this.checkBoxStop = new System.Windows.Forms.CheckBox();
            this.labelBackColor = new System.Windows.Forms.Label();
            this.labelFontColor = new System.Windows.Forms.Label();
            this.checkTP = new System.Windows.Forms.CheckBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.buttonFont = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.buttonLoadRecentLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            this.panelFunctions.SuspendLayout();
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
            // checkBoxStop
            // 
            this.checkBoxStop.AutoSize = true;
            this.checkBoxStop.Location = new System.Drawing.Point(78, 5);
            this.checkBoxStop.Name = "checkBoxStop";
            this.checkBoxStop.Size = new System.Drawing.Size(36, 16);
            this.checkBoxStop.TabIndex = 55;
            this.checkBoxStop.Text = "停";
            this.toolTip.SetToolTip(this.checkBoxStop, "チェックで停止");
            this.checkBoxStop.UseVisualStyleBackColor = true;
            this.checkBoxStop.CheckedChanged += new System.EventHandler(this.checkBoxStop_CheckedChanged);
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
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(3, 2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(24, 23);
            this.buttonOpen.TabIndex = 53;
            this.buttonOpen.Text = "...";
            this.toolTip.SetToolTip(this.buttonOpen, "ファイルを読み込む");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Location = new System.Drawing.Point(120, 3);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            1192296,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(65, 21);
            this.numericUpDownInterval.TabIndex = 56;
            this.numericUpDownInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.numericUpDownInterval, "追加読み込みの間隔");
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownSec_ValueChanged);
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOpacity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numericUpDownOpacity.Location = new System.Drawing.Point(264, 3);
            this.numericUpDownOpacity.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(43, 21);
            this.numericUpDownOpacity.TabIndex = 60;
            this.numericUpDownOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.numericUpDownOpacity, "透け透け度");
            this.numericUpDownOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownOpacity.ValueChanged += new System.EventHandler(this.numericUpDownOpacity_ValueChanged);
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
            // buttonReload
            // 
            this.buttonReload.Location = new System.Drawing.Point(50, 2);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(22, 23);
            this.buttonReload.TabIndex = 54;
            this.buttonReload.Text = "再";
            this.toolTip.SetToolTip(this.buttonReload, "最初から読み込んで処理開始");
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // panelFunctions
            // 
            this.panelFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFunctions.Controls.Add(this.buttonLoadRecentLog);
            this.panelFunctions.Controls.Add(this.checkBoxStop);
            this.panelFunctions.Controls.Add(this.labelBackColor);
            this.panelFunctions.Controls.Add(this.labelFontColor);
            this.panelFunctions.Controls.Add(this.checkTP);
            this.panelFunctions.Controls.Add(this.buttonOpen);
            this.panelFunctions.Controls.Add(this.numericUpDownInterval);
            this.panelFunctions.Controls.Add(this.label2);
            this.panelFunctions.Controls.Add(this.numericUpDownOpacity);
            this.panelFunctions.Controls.Add(this.buttonFont);
            this.panelFunctions.Controls.Add(this.buttonReload);
            this.panelFunctions.Controls.Add(this.label1);
            this.panelFunctions.Location = new System.Drawing.Point(0, 0);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(433, 28);
            this.panelFunctions.TabIndex = 53;
            // 
            // buttonLoadRecentLog
            // 
            this.buttonLoadRecentLog.Location = new System.Drawing.Point(28, 2);
            this.buttonLoadRecentLog.Name = "buttonLoadRecentLog";
            this.buttonLoadRecentLog.Size = new System.Drawing.Size(22, 23);
            this.buttonLoadRecentLog.TabIndex = 64;
            this.buttonLoadRecentLog.Text = "新";
            this.toolTip.SetToolTip(this.buttonLoadRecentLog, "一番最近に作られた LotRO のログを読み込む");
            this.buttonLoadRecentLog.UseVisualStyleBackColor = true;
            this.buttonLoadRecentLog.Click += new System.EventHandler(this.buttonLoadRecentLog_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "ms";
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            this.panelFunctions.ResumeLayout(false);
            this.panelFunctions.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxStop;
        private System.Windows.Forms.Label labelBackColor;
        private System.Windows.Forms.Label labelFontColor;
        private System.Windows.Forms.CheckBox checkTP;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoadRecentLog;
    }
}

