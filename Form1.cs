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
        const string _prefix_version = "δ";
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
            rTextBoxOut.Height -= toolStrip.Height;

            if (Properties.Settings.Default.Dir.Length > 0)
            {
                opf.InitialDirectory = Properties.Settings.Default.Dir;
            }
            else
            {
                opf.InitialDirectory = get_recent_log_path();
            }

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
            if (String.IsNullOrEmpty(recent_log_path)) return;
            load_log(recent_log_path);
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            Reconvert();
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
            if ((String.IsNullOrEmpty(_logpath)) || (_ire == null)) return;

            int num = (int)_ire.Invoke("t.count");
            string str = do_convert("conv_continue");
            if (!String.IsNullOrEmpty(str))
            {
                this.SuspendLayout();

                int scroll_pos_temp = GetScrollPos(rTextBoxOut);
                int sel_start_temp = rTextBoxOut.SelectionStart;
                int sel_length_temp = rTextBoxOut.SelectionLength;

                AppendRtfToRichTextBox(rTextBoxOut, GetRTF(str, num));

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
            formFontSettings.Instance.SetIronRubyInstance(_ire);
        }

        private void formTororo_Activated(object sender, EventArgs e)
        {
            set_gui_mode(true);
            //ここにスクロール位置を戻す処理を入れたらいいかも？
        }

        private void formTororo_Deactivate(object sender, EventArgs e)
        {
            set_gui_mode(false);
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
    }
}
