using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Scripting.Hosting;
using IronRuby;
using IronRuby.Builtins;
using System.Diagnostics;

namespace tororo_gui
{
    public partial class formTororo : Form
    {

        private void load_log(string path)
        {
            if (File.Exists(path))
            {
                start();
                convert_log(path);
                _logpath = path;
                Properties.Settings.Default.Dir = path;
                this.Text = create_version_string(
                _application_name, _prefix_version, _core_version, _gui_version
                ) + " - " + Path.GetFileName(path);
            }
        }

        private void start()
        {
            toolStripButtonStop.Enabled = true;
            toolStripButtonStop.Checked = false;
            timerContinue.Enabled = false;
            timerContinue.Enabled = true;
        }
        
        public void Reconvert()
        {
            if (String.IsNullOrEmpty(_logpath)) return;
            int sel_start_temp = rTextBoxOut.SelectionStart;
            int sel_length_temp = rTextBoxOut.SelectionLength;
            int scroll_pos_temp = GetScrollPos(rTextBoxOut);
            start();
            convert_log(_logpath);
            rTextBoxOut.SelectionStart = sel_start_temp;
            rTextBoxOut.SelectionLength = sel_length_temp;
            SetScrollPos(ref rTextBoxOut, scroll_pos_temp);
            // メインウィンドウをアクティブ化するとカーソル位置に勝手にスクロールしてしまう不具合がある
        }

        // versions: {prefix, core, gui}
        private string create_version_string(string app_name, params string[] versions)
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

        private string get_recent_log_path()
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
            this.Cursor = Cursors.WaitCursor;
            this.SuspendLayout();
            rTextBoxOut.Rtf = GetRTF(str).Rtf;
            rTextBoxOut.SelectionStart = rTextBoxOut.TextLength;
            ScrollToEnd(ref rTextBoxOut);
            this.Cursor = Cursors.Default;
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

            while (!String.IsNullOrEmpty(rtfline.Text = sr.ReadLine()))
            {
                string attr;
                Font font = GetAttributeFont("default");
                Color color = GetAttributeColor("default_fore");
                if (!String.IsNullOrEmpty(attr = GetLineAttribute(num)))
                {
                    font = GetAttributeFont(attr);
                    color = GetAttributeColor(attr);
                }
                rtfline.Font = font;
                rtfline.SelectAll();
                rtfline.SelectionColor = color;

                // キャラクタ名の色変え
                int begin = 0, end = 0;
                if (get_character_name_offset(num, ref begin, ref end))
                {
                    rtfline.SelectionStart = begin;
                    rtfline.SelectionLength = end - begin;
                    rtfline.SelectionColor = GetCharacterNameColor();
                }
                // 行の追加
                AppendRtfToRichTextBox(richtb, rtfline);

                num++;
            }

            return richtb;
        }

        private bool get_character_name_offset(int num, ref int begin, ref int end)
        {
            object ra;
            if ((ra = _ire.Invoke("t.get_log_charaname_offsets_each_line(" + num + ")")) != null)
            {
                Array offset = ((RubyArray)ra).ToArray();
                begin = (int)offset.GetValue(0);
                end = (int)offset.GetValue(1);
                return true;
            }
            return false;
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
            if ((ms = _ire.Invoke("t.get_log_attributes_each_line(" + num + ")")) != null)
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

        private Color GetCharacterNameColor()
        {
            Color color = formFontSettings.Instance.GetColor("default_char", true);
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

        private void set_gui_mode(bool full)
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
                rTextBoxOut.Top = toolStrip.Height;
                rTextBoxOut.Left = toolStrip.Left;
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
                rTextBoxOut.Location = toolStrip.Location;
            }
            this.ResumeLayout();
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