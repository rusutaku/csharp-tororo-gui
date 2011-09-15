namespace tororo_gui
{
    partial class formFontSettings
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
            if (disposing && (components != null)) {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFont = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPreview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSetDefault = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDefaultFont = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonHighlight = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonDefaultFontColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDefaultCharColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAttribute,
            this.ColumnFont,
            this.ColumnColor,
            this.ColumnPreview,
            this.ColumnSetDefault});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv.Location = new System.Drawing.Point(1, 60);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 21;
            this.dgv.Size = new System.Drawing.Size(498, 213);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // ColumnAttribute
            // 
            this.ColumnAttribute.HeaderText = "属性";
            this.ColumnAttribute.Name = "ColumnAttribute";
            this.ColumnAttribute.ReadOnly = true;
            this.ColumnAttribute.Width = 54;
            // 
            // ColumnFont
            // 
            this.ColumnFont.HeaderText = "フォント設定";
            this.ColumnFont.Name = "ColumnFont";
            this.ColumnFont.Width = 70;
            // 
            // ColumnColor
            // 
            this.ColumnColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnColor.HeaderText = "色設定";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.Width = 47;
            // 
            // ColumnPreview
            // 
            this.ColumnPreview.HeaderText = "プレビュー";
            this.ColumnPreview.Name = "ColumnPreview";
            this.ColumnPreview.ReadOnly = true;
            this.ColumnPreview.Width = 200;
            // 
            // ColumnSetDefault
            // 
            this.ColumnSetDefault.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnSetDefault.HeaderText = "標準に戻す";
            this.ColumnSetDefault.Name = "ColumnSetDefault";
            this.ColumnSetDefault.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSetDefault.Width = 66;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(232, 279);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(413, 279);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "適用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(322, 279);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "標準フォント";
            // 
            // buttonDefaultFont
            // 
            this.buttonDefaultFont.AutoSize = true;
            this.buttonDefaultFont.Location = new System.Drawing.Point(12, 24);
            this.buttonDefaultFont.Name = "buttonDefaultFont";
            this.buttonDefaultFont.Size = new System.Drawing.Size(191, 30);
            this.buttonDefaultFont.TabIndex = 5;
            this.buttonDefaultFont.UseVisualStyleBackColor = true;
            this.buttonDefaultFont.Click += new System.EventHandler(this.buttonDefaultFont_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "背景色";
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(373, 24);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(52, 30);
            this.buttonBackColor.TabIndex = 7;
            this.buttonBackColor.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "新着ハイライト色";
            this.label3.Visible = false;
            // 
            // buttonHighlight
            // 
            this.buttonHighlight.Location = new System.Drawing.Point(449, 24);
            this.buttonHighlight.Name = "buttonHighlight";
            this.buttonHighlight.Size = new System.Drawing.Size(39, 23);
            this.buttonHighlight.TabIndex = 9;
            this.buttonHighlight.UseVisualStyleBackColor = true;
            this.buttonHighlight.Visible = false;
            // 
            // buttonDefaultFontColor
            // 
            this.buttonDefaultFontColor.Location = new System.Drawing.Point(209, 24);
            this.buttonDefaultFontColor.Name = "buttonDefaultFontColor";
            this.buttonDefaultFontColor.Size = new System.Drawing.Size(52, 30);
            this.buttonDefaultFontColor.TabIndex = 10;
            this.buttonDefaultFontColor.UseVisualStyleBackColor = true;
            this.buttonDefaultFontColor.Click += new System.EventHandler(this.buttonDefaultFontColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "標準フォント色";
            // 
            // buttonDefaultCharColor
            // 
            this.buttonDefaultCharColor.Location = new System.Drawing.Point(289, 24);
            this.buttonDefaultCharColor.Name = "buttonDefaultCharColor";
            this.buttonDefaultCharColor.Size = new System.Drawing.Size(52, 30);
            this.buttonDefaultCharColor.TabIndex = 12;
            this.buttonDefaultCharColor.UseVisualStyleBackColor = true;
            this.buttonDefaultCharColor.Click += new System.EventHandler(this.buttonDefaultCharColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "キャラクタ名色";
            // 
            // formFontSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 314);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDefaultCharColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDefaultFontColor);
            this.Controls.Add(this.buttonHighlight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBackColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDefaultFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dgv);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::tororo_gui.Properties.Settings.Default, "formFontSettingsLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::tororo_gui.Properties.Settings.Default.formFontSettingsLocation;
            this.Name = "formFontSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FontSettings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formFontSettings_FormClosing);
            this.Shown += new System.EventHandler(this.formFontSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDefaultFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonHighlight;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button buttonDefaultFontColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDefaultCharColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAttribute;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnFont;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPreview;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSetDefault;

    }
}