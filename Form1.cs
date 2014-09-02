using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Scripting.Hosting;
using IronRuby;
using IronRuby.Builtins;
using System.Diagnostics;

namespace tororo_gui
{
    public partial class formTororo : Form
    {
        const string _application_name = "tororo";
        const string _prefix_version = "ε1";
        string _gui_version = Application.ProductVersion.ToString();

        string _logpath = "";

        Point _fullmode_point;
        Size  _fullmode_size;
        bool _hold_fullmode = false;

        guiSettings GeneralSettings = new guiSettings("settings-general.xml");

        tororoCoreInterface _tc = new tororoCoreInterface();

        public formTororo()
        {
            InitializeComponent();
            
            Properties.Settings.Default.SettingChanging += new System.Configuration.SettingChangingEventHandler(Default_SettingChanging);

            this.ClientSize = Properties.Settings.Default.formTororoSize;

            toolStripNumericUpDownOpacity.NumericUpDownControl.Minimum = 50;
            toolStripNumericUpDownOpacity.NumericUpDownControl.Maximum = 100;
            toolStripNumericUpDownOpacity.NumericUpDownControl.Increment = 2;
            toolStripNumericUpDownInterval.NumericUpDownControl.Minimum = 50;
            toolStripNumericUpDownInterval.NumericUpDownControl.Maximum = 5000;
            toolStripNumericUpDownInterval.NumericUpDownControl.Increment = 50;

            decimal opacity = 100;
            decimal interval = 50;
            bool transparency = false;
            bool minimode = true;
            bool scroll_to_end = true;

            GeneralSettings.LoadSettings();
            if (!GeneralSettings.IsEmpty())
            {
                opacity = (decimal)GeneralSettings.GetCorrectly("opacity", TypeCode.Decimal, opacity);
                interval = (decimal)GeneralSettings.GetCorrectly("interval", TypeCode.Decimal, interval);
                transparency = (bool)GeneralSettings.GetCorrectly("transparency", TypeCode.Boolean, transparency);
                minimode = (bool)GeneralSettings.GetCorrectly("minimode", TypeCode.Boolean, minimode);
                scroll_to_end = (bool)GeneralSettings.GetCorrectly("scroll_to_end", TypeCode.Boolean, scroll_to_end);
            }

            toolStripNumericUpDownOpacity.NumericUpDownControl.Value = opacity;
            toolStripNumericUpDownInterval.NumericUpDownControl.Value = interval;
            toolStripCheckTP.Checked = transparency;
            toolStripCheckScroll.Checked = scroll_to_end;

            rTextBoxOut.Size = this.ClientSize;
            rTextBoxOut.Height -= toolStripEx.Height;

            if (Properties.Settings.Default.Dir.Length > 0)
            {
                opf.InitialDirectory = Properties.Settings.Default.Dir;
            }
            else
            {
                opf.InitialDirectory = GetRecentLogPath();
            }
            opf.InitialDirectory = Path.GetDirectoryName(opf.InitialDirectory);

            this.Text = GetVersionString(
                _application_name, _prefix_version, _tc.GetVersion(), _gui_version
                );
            // 行間を詰める
            rTextBoxOut.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
        }

        private void formTororoTest_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            InitialConvert(files[0]);
        }

        private void formTororoTest_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                // ドラッグ中のファイルやディレクトリの取得
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string d in drags) {
                    if (!System.IO.File.Exists(d)) {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            _hold_fullmode = true;
            if (opf.ShowDialog() == DialogResult.OK) {
                InitialConvert(opf.FileName);
            }
            _hold_fullmode = false;
        }

        private void toolStripButtonLoadRecentLog_Click(object sender, EventArgs e)
        {
            string recent_log_path;
            recent_log_path = GetRecentLogPath();
            if (String.IsNullOrEmpty(recent_log_path)) return;
            InitialConvert(recent_log_path);
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            Reconvert();
        }

        private void toolStripButtonStop_CheckedChanged(object sender, EventArgs e)
        {
            if (_tc == null) {
                toolStripButtonStop.CheckState = CheckState.Unchecked;
            }
            timerContinue.Enabled = !toolStripButtonStop.Checked;
            toolStripLabelStopping.Visible = toolStripButtonStop.Checked;
        }

        private void timerContinue_Tick(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(_logpath)) || (_tc == null)) return;

            int line_num = _tc.GetProcessedLineNum();
            string str = _tc.ContinueConvert();
            if (!String.IsNullOrEmpty(str))
            {
                this.SuspendLayout();

                int scroll_pos_temp = GetScrollPos(rTextBoxOut);
                int sel_start_temp = rTextBoxOut.SelectionStart;
                int sel_length_temp = rTextBoxOut.SelectionLength;

                AppendRtfToRichTextBox(rTextBoxOut, GetRTF(str, line_num));

                //選択開始位置がここで 0 にリセットされるので注意 ->

                //RTF をつなげたときの余分な改行を削除
                //rTextBoxOut.Rtf.Replace("\\par\r\n\\par\r\n", "\\par\r\n");
                rTextBoxOut.Rtf = rTextBoxOut.Rtf.Remove(rTextBoxOut.Rtf.Length - 9, 6);

                //<-

                if (toolStripCheckScroll.Checked)
                {
                    rTextBoxOut.SelectionStart = rTextBoxOut.TextLength;
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        ScrollToEnd(ref rTextBoxOut);
                    }
                }
                else
                {
                    rTextBoxOut.SelectionStart = sel_start_temp;
                    rTextBoxOut.SelectionLength = sel_length_temp;
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        SetScrollPos(ref rTextBoxOut, scroll_pos_temp);
                    }
                }
                this.ResumeLayout();
            }
        }

        private void toolStripNumericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            if (toolStripNumericUpDownInterval.NumericUpDownControl.Value == 0)
            {
                timerContinue.Enabled = false;
            } else {
                timerContinue.Interval = (int)toolStripNumericUpDownInterval.NumericUpDownControl.Value;
                timerContinue.Enabled = true;
            }
        }

        private void toolStripNumericUpDownOpacity_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = (double)toolStripNumericUpDownOpacity.NumericUpDownControl.Value * 0.01;
        }

        private void formTororo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.formTororoSize = this.ClientSize; //サイズがおかしくなるのを回避
            Properties.Settings.Default.Save();
        }

        private void formTororo_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralSettings.Set("minimode", toolStripCheckMinimode.Checked);
            GeneralSettings.Set("scroll_to_end", toolStripCheckScroll.Checked);
            GeneralSettings.Set("transparency", toolStripCheckTP.Checked);
            GeneralSettings.Set("opacity", toolStripNumericUpDownOpacity.NumericUpDownControl.Value);
            GeneralSettings.Set("interval", toolStripNumericUpDownInterval.NumericUpDownControl.Value);

            GeneralSettings.Save();
            
            if (!String.IsNullOrEmpty(_logpath))
            {
                Properties.Settings.Default.Dir = Path.GetDirectoryName(_logpath);
            }
        }

        private void toolStripCheckTP_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripCheckTP.Checked) {
                this.TransparencyKey = rTextBoxOut.BackColor;
            } else {
                this.TransparencyKey = new Color();
            }
        }

        private void toolStripButtonFontSettings_Click(object sender, EventArgs e)
        {
            formFontSettings.Instance.Show();
            this.AddOwnedForm(formFontSettings.Instance);
            formFontSettings.Instance.SetCoreInstance(_tc);
        }

        private void formTororo_Activated(object sender, EventArgs e)
        {
            SetGUIMode(true);
            //ここにスクロール位置を戻す処理を入れたらいいかも？
        }

        private void formTororo_Deactivate(object sender, EventArgs e)
        {
            SetGUIMode(false);
        }

        void Default_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                if ((e.SettingName == "formTororoSize") || (e.SettingName == "formTororoLocation"))
                {
                    e.Cancel = true;
                }
            }
        }

        // ここより先，Form1_Methods.cs からマージ．
        private void InitialConvert(string path)
        {
            if (File.Exists(path))
            {
                _logpath = path;
                Convert();
                Properties.Settings.Default.Dir = path;
                this.Text = GetVersionString(
                _application_name, _prefix_version, _tc.GetVersion(), _gui_version
                ) + " - " + Path.GetFileName(path);
            }
        }

        private void Convert()
        {
            toolStripButtonStop.Enabled = true;
            toolStripButtonStop.Checked = false;
            timerContinue.Enabled = false;
            timerContinue.Enabled = true;
            this.Cursor = Cursors.WaitCursor;
            this.SuspendLayout();
            rTextBoxOut.Rtf = GetRTF(_tc.ConvertLog(_logpath)).Rtf;
            rTextBoxOut.SelectionStart = rTextBoxOut.TextLength;
            ScrollToEnd(ref rTextBoxOut);
            this.Cursor = Cursors.Default;
            this.ResumeLayout();
        }

        public void Reconvert()
        {
            if (String.IsNullOrEmpty(_logpath)) return;
            int sel_start_temp = rTextBoxOut.SelectionStart;
            int sel_length_temp = rTextBoxOut.SelectionLength;
            int scroll_pos_temp = GetScrollPos(rTextBoxOut);
            Convert();
            rTextBoxOut.SelectionStart = sel_start_temp;
            rTextBoxOut.SelectionLength = sel_length_temp;
            SetScrollPos(ref rTextBoxOut, scroll_pos_temp);
            // メインウィンドウをアクティブ化するとカーソル位置に勝手にスクロールしてしまう不具合がある
        }

        // versions: {prefix, core, gui}
        private string GetVersionString(string app_name, params string[] versions)
        {
            string prefix = versions[0];
            string core = versions[1];
            string gui = versions[2];
            string output = app_name;

            if (!String.IsNullOrEmpty(prefix))
            {
                output += " " + prefix;
            }
            if (!String.IsNullOrEmpty(core))
            {
                output += " c:" + core;
            }
            if (!String.IsNullOrEmpty(gui))
            {
                output += " g:" + gui;
            }
            return output;
        }

        private string GetRecentLogPath()
        {
            string recent_file_path = "";
            string[] file_path_list;
            DateTime recent_date = DateTime.MinValue;
            file_path_list = System.IO.Directory.GetFiles(
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + @"\The Lord of the Rings Online", "*.txt");
            if (file_path_list == null) return null;
            foreach (string file_path in file_path_list)
            {
                DateTime temp_date;
                temp_date = System.IO.File.GetCreationTime(file_path);
                if (temp_date > recent_date)
                {
                    recent_date = temp_date;
                    recent_file_path = file_path;
                }
            }
            return recent_file_path;
        }



        private RichTextBox GetRTF(string str, int start_line_num = 0)
        {
            RichTextBox richtb = new RichTextBox();
            RichTextBox rtfline = new RichTextBox(); //一行分のリッチテキスト
            StringReader sr = new StringReader(str);
            int line_num = start_line_num;

            richtb.Font = rTextBoxOut.Font;
            richtb.ForeColor = rTextBoxOut.ForeColor;
            richtb.BackColor = rTextBoxOut.BackColor;

            while (!String.IsNullOrEmpty(rtfline.Text = sr.ReadLine()))
            {
                string attr;
                Font font = GetAttributeFont("default");
                Color color = GetAttributeColor("default_fore");
                Color char_color = GetAttributeColor("default_char");
                if (!String.IsNullOrEmpty(attr = _tc.GetLineAttribute(line_num)))
                {
                    font = GetAttributeFont(attr);
                    color = GetAttributeColor(attr);
                    char_color = GetAttributeColor(attr + "_char");
                }
                rtfline.Font = font;
                rtfline.SelectAll();
                rtfline.SelectionColor = color;

                // キャラクタ名の色変え
                int begin = 0, end = 0;
                if (_tc.GetCharacterNameOffset(line_num, ref begin, ref end))
                {
                    rtfline.SelectionStart = begin;
                    rtfline.SelectionLength = end - begin;
                    rtfline.SelectionColor = char_color;
                }
                // 行の追加
                AppendRtfToRichTextBox(richtb, rtfline);

                line_num++;
            }

            return richtb;
        }

        /// <summary>
        /// RichTextBoxの末尾にRTFを追加
        /// </summary>
        /// <param name="rtb0">RTFを追加するRichTextBox</param>
        /// <param name="rtb1">追加するRichTextBox</param>
        public static void AppendRtfToRichTextBox(
            RichTextBox rtb0, RichTextBox rtb1)
        {
            rtb0.SelectionStart = rtb0.TextLength;
            rtb0.SelectedRtf = rtb1.Rtf;
        }

        private Font GetAttributeFont(string attr)
        {
            Font font = formFontSettings.Instance.GetFont(attr, true);
            return font;
        }

        private Color GetAttributeColor(string attr)
        {
            Color color = formFontSettings.Instance.GetColor(attr, true);
            return color;
        }

        private Color GetCharacterNameColor()
        {
            Color color = formFontSettings.Instance.GetColor("default_char_color", true);
            return color;
        }

        private void SetGUIMode(bool full)
        {

            if (this.WindowState.Equals(FormWindowState.Minimized) || _hold_fullmode) return;
            this.SuspendLayout();
            Point minimode_point = PointToScreen(rTextBoxOut.Bounds.Location);
            switch (this.FormBorderStyle)
            {
                case FormBorderStyle.None:

                    break;
                case FormBorderStyle.Sizable:
                    _fullmode_point = this.Location;
                    _fullmode_size = this.ClientSize;
                    break;
            }

            if (full)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = _fullmode_point;
                this.ClientSize = _fullmode_size;
                rTextBoxOut.SelectionLength = 0;
                rTextBoxOut.Top = toolStripEx.Height;
                rTextBoxOut.Left = toolStripEx.Left;
            }
            else if (toolStripCheckMinimode.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = minimode_point;
                this.ClientSize = rTextBoxOut.Size;
                // スクロールバーを隠す
                // 強力透過の場合は半分だけ隠す
                if (toolStripCheckTP.Checked)
                {
                    this.Width -= SystemInformation.VerticalScrollBarWidth / 2;
                }
                else
                {
                    this.Width -= SystemInformation.VerticalScrollBarWidth;
                }
                rTextBoxOut.Location = toolStripEx.Location;
            }
            this.ResumeLayout();
        }

    }
}
