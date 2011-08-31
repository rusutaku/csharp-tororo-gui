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

namespace tororo_gui
{
    public partial class formTororo : Form
    {
        const string _application_name = "tororo";
        const string _prefix_version = "pre δ";
        string _gui_version = Application.ProductVersion.ToString();
        string _core_version;

        string _logpath = "";

        Point _fullmode_point;
        Size  _fullmode_size;
        bool _hold_fullmode = false;

        guiSettings GeneralSettings = new guiSettings("settings-general.xml");

        IronRubyScriptEngine _ire;

        public formTororo()
        {
            InitializeComponent();
            _ire = new IronRubyScriptEngine();

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

            GeneralSettings.LoadSettings();
            if (!GeneralSettings.IsEmpty())
            {
                opacity = (decimal)GeneralSettings.GetCorrectly("opacity", TypeCode.Decimal, 100);
                interval = (decimal)GeneralSettings.GetCorrectly("interval", TypeCode.Decimal, 500);
                transparency = (bool)GeneralSettings.GetCorrectly("transparency", TypeCode.Boolean, false);
            }

            toolStripNumericUpDownOpacity.NumericUpDownControl.Value = opacity;
            toolStripNumericUpDownInterval.NumericUpDownControl.Value = interval;
            toolStripCheckTP.Checked = transparency;

            rTextBoxOut.Size = this.ClientSize;
            rTextBoxOut.Height -= toolStrip.Height;
            //rTextBoxOut.Font = fontDialog.Font
            //    = Properties.Settings.Default.Font;
            //rTextBoxOut.ForeColor = Properties.Settings.Default.FontColor;
            //rTextBoxOut.BackColor = Properties.Settings.Default.BackColor;
            opf.InitialDirectory = Properties.Settings.Default.Dir;
            load_core();
        }

        private void formTororoTest_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            load_log(files[0]);
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

        private void load_log(string path)
        {
            if (File.Exists(path)) {
                this.Cursor = Cursors.WaitCursor;
                start();
                convert_log(path);
                _logpath = path;
                Properties.Settings.Default.Dir = path;
                this.Text = create_version_string(
                _application_name, _prefix_version, _core_version, _gui_version
                ) + " - " + Path.GetFileName(path);
                this.Cursor = Cursors.Default;
            }
        }

        private void start()
        {
            toolStripButtonStop.Enabled = true;
            toolStripButtonStop.Checked = false;
            timerContinue.Enabled = false;
            timerContinue.Enabled = true;
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            _hold_fullmode = true;
            if (opf.ShowDialog() == DialogResult.OK) {
                load_log(opf.FileName);
            }
            _hold_fullmode = false;
        }

        private void toolStripButtonLoadRecentLog_Click(object sender, EventArgs e)
        {
            string recent_log_path;
            recent_log_path = get_recent_log_path();
            if (recent_log_path == null) return;
            load_log(recent_log_path);
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            Reconvert();
        }

        public void Reconvert()
        {
            if (_logpath == "") return;
            start();
            convert_log(_logpath);
        }

        private void toolStripButtonStop_CheckedChanged(object sender, EventArgs e)
        {
            if (_ire == null) {
                toolStripButtonStop.CheckState = CheckState.Unchecked;
            }
            timerContinue.Enabled = !toolStripButtonStop.Checked;
        }

        private void timerContinue_Tick(object sender, EventArgs e)
        {
            if ((_logpath == "") || (_ire == null)) return;
            // this.Cursor = Cursors.WaitCursor;
            int num = (int)_ire.Invoke("t.count");
            string str = do_convert("conv_continue");
            if (str != "")
            {
                this.SuspendLayout();

                AppendRtfToRichTextBox(rTextBoxOut, GetRTF(str, num));
                rTextBoxOut.Rtf = rTextBoxOut.Rtf.Replace("\\par\r\n\\par\r\n", "\\par\r\n");
                //if (!IsEndOfScroll())
                //{
                    ScrollToEnd();
                //}
                this.ResumeLayout();
            }
            // this.Cursor = Cursors.Default;
        }

        private void ScrollToEnd()
        {
            rTextBoxOut.SelectionStart = rTextBoxOut.Text.Length;
            rTextBoxOut.ScrollToCaret();
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
            Properties.Settings.Default.formTororoSize = this.ClientSize;
            Properties.Settings.Default.Save();
        }

        private void formTororo_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralSettings.Set("transparency", toolStripCheckTP.Checked);
            GeneralSettings.Set("opacity", toolStripNumericUpDownOpacity.NumericUpDownControl.Value);
            GeneralSettings.Set("interval", toolStripNumericUpDownInterval.NumericUpDownControl.Value);
            //if (logpath != "")
            //{
            //    GeneralSettings.Set("logdir", Path.GetDirectoryName(logpath));
            //}
            GeneralSettings.Save();
            
            //Properties.Settings.Default.Font = rTextBoxOut.Font;
            //Properties.Settings.Default.FontColor = rTextBoxOut.ForeColor;
            //Properties.Settings.Default.BackColor = rTextBoxOut.BackColor;
            //Properties.Settings.Default.Interval = interval;
            //Properties.Settings.Default.Opacity = numericUpDownOpacity.Value;
            //Properties.Settings.Default.Transparent = checkTP.Checked;
            if (_logpath != "")
            {
                Properties.Settings.Default.Dir = Path.GetDirectoryName(_logpath);
            }
            //Properties.Settings.Default.formTororoLocation = this.RestoreBounds.Location;
            //Properties.Settings.Default.formTororoSize = this.RestoreBounds.Size;
            
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
            formFontSettings.Instance.SetIronRubyInstance(_ire);
        }

        // versions: {prefix, core, gui}
        private string create_version_string(string app_name, params string[] versions)
        {
            string prefix = versions[0];
            string core = versions[1];
            string gui = versions[2];
            string output = app_name;

            if (prefix != "") {
                output += " " + prefix;
            }
            if (core != "") {
                output += " c:" + core;
            }
            if (gui != "") {
                output += " g:" + gui;
            }
            return output;
        }

        private string get_recent_log_path()
        {
            string recent_file_path = "";
            string[] file_path_list;
            DateTime recent_date = DateTime.MinValue;
            file_path_list = System.IO.Directory.GetFiles(
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + @"\The Lord of the Rings Online", "*.txt");
            if (file_path_list == null) return null;
            foreach(string file_path in file_path_list) {
                DateTime temp_date;
                temp_date = System.IO.File.GetCreationTime(file_path);
                if (temp_date > recent_date) {
                    recent_date = temp_date;
                    recent_file_path = file_path;
                }
            }
            return recent_file_path;
        }

        private void formTororo_Activated(object sender, EventArgs e)
        {
            set_gui_mode(true);
        }

        private void formTororo_Deactivate(object sender, EventArgs e)
        {
            set_gui_mode(false);
        }

        private void set_gui_mode(bool full)
        {
            if (this.WindowState.Equals(FormWindowState.Minimized) || _hold_fullmode) return;
            this.SuspendLayout();
            Point minimode_point = PointToScreen(rTextBoxOut.Bounds.Location);
            switch (this.FormBorderStyle) {
                case FormBorderStyle.None:
                    
                    break;
                case FormBorderStyle.Sizable:
                    _fullmode_point = this.Location;
                    _fullmode_size  = this.ClientSize;
                    break;
            }

            if (full) {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = _fullmode_point;
                this.ClientSize = _fullmode_size;
                rTextBoxOut.SelectionLength = 0;
                rTextBoxOut.Top  = toolStrip.Height;
                rTextBoxOut.Left = toolStrip.Left;
            }
            else if (toolStripMinimode.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = minimode_point;
                this.ClientSize = rTextBoxOut.Size;
                // スクロールバーを隠す
                // 強力透過の場合は半分だけ隠す
                if (toolStripCheckTP.Checked) {
                    this.Width -= SystemInformation.VerticalScrollBarWidth / 2;
                } else {
                    this.Width -= SystemInformation.VerticalScrollBarWidth;
                }
                rTextBoxOut.Location = toolStrip.Location;
            }
            this.ResumeLayout();
        }

        private void load_core()
        {
            _ire.ExecuteFile("tororo.rb");
            _ire.Invoke("t = Tororo.new");
            _core_version = _ire.Invoke("t.version").ToString();
            this.Text = create_version_string(
                _application_name, _prefix_version, _core_version, _gui_version
                );
        }

        private string do_convert(string command)
        {

            // 戻り値は UTF8 の文字列
            var result = _ire.Invoke("t." + command);
            string str;

            str = result.ToString();
            if (((IronRuby.Builtins.MutableString)(result)).Encoding.Name == "ASCII-8BIT")
            {
                str = reviveCode(str); // 修復する
            }
            return str;
        }
        private void convert_log(string filepath)
        {
            string str = do_convert("conv_from_log('" + filepath + "')");
            this.SuspendLayout();
            rTextBoxOut.Rtf = GetRTF(str).Rtf;
            ScrollToEnd();
            this.ResumeLayout();
        }

        private RichTextBox GetRTF(string str, int num = 0)
        {
            RichTextBox richtb = new RichTextBox();
            RichTextBox rtfline = new RichTextBox(); //一行分のリッチテキスト
            StringReader sr = new StringReader(str);

            richtb.Font = rTextBoxOut.Font;
            richtb.ForeColor = rTextBoxOut.ForeColor;
            richtb.BackColor = rTextBoxOut.BackColor;
            
            while ((rtfline.Text = sr.ReadLine()) != null)
            {
                string attr;
                Font font = GetAttributeFont("default");
                Color color = GetAttributeColor("default_fore");
                if ((attr = GetLineAttribute(num)) != null)
                {
                    font = GetAttributeFont(attr);
                    color = GetAttributeColor(attr);
                }
                rtfline.Font = font;
                rtfline.ForeColor = color;
                // キャラクタ名の色変え
                // int start, end;
                // GetCharacterNameOffset(ref start, ref end);
                // richline.SelectionStart = start;
                // richline.SelectionLength = end - start;
                // richline.SelectionColor = ...;
                // 行の追加
                AppendRtfToRichTextBox(richtb, rtfline);

                num++;
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

        private string GetLineAttribute(int num)
        {
            object ms; // MutableString のつもり
            if ((ms = _ire.Invoke("t.get_line_attribute(" + num + ")")) != null)
            {
                return ms.ToString();
            }
            else
            {
                return null;
            }
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

        // 文字化けを直す
        private string reviveCode(string broken)
        {
            byte[] b, r;
            string rev;
            b = Encoding.Unicode.GetBytes(broken); // バイト配列に分解
            r = new byte[b.Length / 2]; // UTF8のバイト配列
            int j = 0;
            // 0x00 のバイトを削って詰める（奇数バイト）
            for (int i = 0; i < b.Length; i += 2)
            {
                r[j++] = b[i];
            }
            // 正しい UTF8 のバイト配列を得たが，textBox が扱えるのは UTF16
            // なので UTF8 -> UTF16(Unicode) 変換
            r = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, r);
            rev = Encoding.Unicode.GetString(r); // 文字列に変換
            return rev;
        }

        /*
        public void initialize_settings()
        {
            Hash ht = (Hash)ire.Invoke("");
        }
        public bool load_settings()
        {
            return true;
        }
        */
    }
}
