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
        const string application_name = "tororo";
        const string prefix_version = "β";
        string gui_version = Application.ProductVersion.ToString();
        string core_version;

        string logpath = "";

        Point fullmode_point;
        Size  fullmode_size;
        bool hold_fullmode = false;

        decimal interval;
        decimal opacity;
        bool transparent;

        IronRubyScriptEngine ire;

        public formTororo()
        {
            InitializeComponent();
            ire = new IronRubyScriptEngine();
            this.Top    = Properties.Settings.Default.Top;
            this.Left   = Properties.Settings.Default.Left;
            this.Width  = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;
            textBoxOut.Font = fontDialog.Font
                = Properties.Settings.Default.Font;
            textBoxOut.ForeColor = labelFontColor.BackColor
                = Properties.Settings.Default.FontColor;
            textBoxOut.BackColor = labelBackColor.BackColor
                = Properties.Settings.Default.BackColor;
            interval = Properties.Settings.Default.Interval;
            opacity = Properties.Settings.Default.Opacity;
            transparent = Properties.Settings.Default.Transparent;
            opf.InitialDirectory = Properties.Settings.Default.Dir;
            this.Text = create_version_string(
                application_name, prefix_version, "", gui_version
                );
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
                logpath = path;
                Properties.Settings.Default.Dir = path;
                this.Text = create_version_string(
                application_name, prefix_version, core_version, gui_version
                ) + " - " + Path.GetFileName(path);
                this.Cursor = Cursors.Default;
            }
        }

        private void start()
        {
            toolStripButtonStop.Checked = false;
            timerContinue.Enabled = false;
            ire.ExecuteFile("tororo.rb");
            ire.Invoke("t = Tororo.new");
            core_version = ire.Invoke("t.version").ToString();
            this.Text = create_version_string(
                application_name, prefix_version, core_version, gui_version
                );
            timerContinue.Enabled = true;
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            hold_fullmode = true;
            if (opf.ShowDialog() == DialogResult.OK) {
                load_log(opf.FileName);
            }
            hold_fullmode = false;
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
            if (logpath == "") return;
            start();
            convert_log(logpath);
        }

        private void toolStripButtonStop_CheckedChanged(object sender, EventArgs e)
        {
            if (ire == null) {
                toolStripButtonStop.CheckState = CheckState.Unchecked;
            }
            timerContinue.Enabled = !toolStripButtonStop.Checked;
        }

        private string do_convert(string command)
        {

            // 戻り値は UTF8 の文字列
            var result = ire.Invoke("t." + command);
            string str;

            str = result.ToString();
            if (((IronRuby.Builtins.MutableString)(result)).Encoding.Name == "ASCII-8BIT") {
                str = reviveCode(str); // 修復する
            }
            return str;
        }
        private void convert_log(string filepath)
        {
            string str = do_convert("conv_from_log('" + filepath + "')");
            textBoxOut.Text = str;
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
            for (int i = 0; i < b.Length; i += 2) {
                r[j++] = b[i];
            }
            // 正しい UTF8 のバイト配列を得たが，textBox が扱えるのは UTF16
            // なので UTF8 -> UTF16(Unicode) 変換
            r = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, r);
            rev = Encoding.Unicode.GetString(r); // 文字列に変換
            return rev;
        }

        private void textBoxOut_TextChanged(object sender, EventArgs e)
        {
            textBoxOut.SelectionStart = textBoxOut.Text.Length;
            textBoxOut.ScrollToCaret();
        }

        private void timerContinue_Tick(object sender, EventArgs e)
        {
            if ((logpath == "") || (ire == null)) return;
            // this.Cursor = Cursors.WaitCursor;
            string str = do_convert("conv_continue");
            textBoxOut.Text += str;
            // this.Cursor = Cursors.Default;
        }
        /*
        private void numericUpDownSec_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownInterval.Value == 0) {
                timerContinue.Enabled = false;
            } else {
                timerContinue.Interval = (int)numericUpDownInterval.Value;
                timerContinue.Enabled = true;
            }
        }
        */
        private void numericUpDownOpacity_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = (double)numericUpDownOpacity.Value * 0.01;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            hold_fullmode = true;
            if (fontDialog.ShowDialog() == DialogResult.OK) {
                textBoxOut.Font = fontDialog.Font;
            }
            hold_fullmode = false;
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {
            textBoxOut.Font = fontDialog.Font;
        }

        private void formTororo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) {
                Properties.Settings.Default.Top = this.Top;
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
            } else {
                Properties.Settings.Default.Top = this.RestoreBounds.Top;
                Properties.Settings.Default.Left = this.RestoreBounds.Left;
                Properties.Settings.Default.Width = this.RestoreBounds.Width;
                Properties.Settings.Default.Height = this.RestoreBounds.Height;
            }
            Properties.Settings.Default.Font = textBoxOut.Font;
            Properties.Settings.Default.FontColor = textBoxOut.ForeColor;
            Properties.Settings.Default.BackColor = textBoxOut.BackColor;
            Properties.Settings.Default.Interval = interval;
            Properties.Settings.Default.Opacity = numericUpDownOpacity.Value;
            Properties.Settings.Default.Transparent = checkTP.Checked;
            if (logpath != "") {
                Properties.Settings.Default.Dir = Path.GetDirectoryName(logpath);
            }
            Properties.Settings.Default.Save();
        }

        private void labelFontColor_Click(object sender, EventArgs e)
        {
            hold_fullmode = true;
            colorDialog.Color = labelFontColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                textBoxOut.ForeColor = colorDialog.Color;
                labelFontColor.BackColor = colorDialog.Color;
            }
            hold_fullmode = false;
        }

        private void labelBackColor_Click(object sender, EventArgs e)
        {
            hold_fullmode = true;
            colorDialog.Color = labelBackColor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                checkTP.Checked = false;
                textBoxOut.BackColor = colorDialog.Color;
                labelBackColor.BackColor = colorDialog.Color;
            }
            hold_fullmode = false;
        }

        private void checkTP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTP.Checked) {
                this.TransparencyKey = textBoxOut.BackColor;
            } else {
                this.TransparencyKey = new Color();
            }
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
            if (this.WindowState.Equals(FormWindowState.Minimized) || hold_fullmode) return;
            this.SuspendLayout();
            Point minimode_point = PointToScreen(textBoxOut.Bounds.Location);
            switch (this.FormBorderStyle) {
                case FormBorderStyle.None:
                    
                    break;
                case FormBorderStyle.Sizable:
                    fullmode_point = this.Location;
                    fullmode_size  = this.ClientSize;
                    break;
            }

            if (full) {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Location = fullmode_point;
                this.ClientSize = fullmode_size;
                textBoxOut.SelectionLength = 0;
                textBoxOut.Top  = panelFunctions.Height;
                textBoxOut.Left = panelFunctions.Left;
            } else {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = minimode_point;
                this.ClientSize = textBoxOut.Size;
                // スクロールバーを隠す
                // 強力透過の場合は半分だけ隠す
                if (checkTP.Checked) {
                    this.Width -= SystemInformation.VerticalScrollBarWidth / 2;
                } else {
                    this.Width -= SystemInformation.VerticalScrollBarWidth;
                }
                textBoxOut.Location = panelFunctions.Location;
            }
            this.ResumeLayout();
        }
    }
}
