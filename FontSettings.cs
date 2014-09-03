using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IronRuby.Builtins;

namespace tororo_gui
{
    public partial class formFontSettings : Form
    {
        Font  FONT = SystemFonts.CaptionFont;
        Color FONT_COLOR = Color.LightBlue;
        Color CHAR_COLOR = Color.White;
        Color BACK_COLOR = Color.FromArgb(16,16,16);
        Color HIGHLIGHT = Color.DeepPink;

        const string SET = "*";
 
        tororoCoreInterface _tc = new tororoCoreInterface();

        bool _changed = false;

        guiSettings FontSettings = new guiSettings("settings-font.xml");

        private formFontSettings()
        {
            InitializeComponent();

            this.ClientSize = Properties.Settings.Default.formFontSettingsSize;

            FontSettings.LoadSettings();
            Font default_font;
            Color default_font_color;
            Color default_char_color;
            Color backcolor;
            Color highlight;
            if (FontSettings.IsEmpty())
            {
                default_font = FONT;
                default_font_color = FONT_COLOR;
                default_char_color = CHAR_COLOR;
                backcolor = BACK_COLOR;
                highlight = HIGHLIGHT;
            }
            else
            {
                default_font = GetFont("default");
                default_font_color = GetColor("default_fore");
                default_char_color = GetColor("default_char");
                backcolor = GetColor("default_back");
                highlight = GetColor("default_highlight");
            }


            buttonDefaultFont.Text = GetFontInfoInString(default_font);
            buttonDefaultFont.Font = default_font;
            buttonDefaultFont.ForeColor = default_font_color;
            buttonDefaultFont.BackColor = backcolor;
            buttonDefaultFontColor.BackColor = default_font_color;
            buttonDefaultCharColor.BackColor = default_char_color;
            buttonBackColor.BackColor = backcolor;
            buttonHighlight.BackColor = highlight;
            SaveDefaultSettings();
            //FontSettings.Save();

        }

        private static formFontSettings _instance;

        //フォームにアクセスするためのプロパティ
        public static formFontSettings Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new formFontSettings();
                return _instance;
            }
        }

        private void formFontSettings_Shown(object sender, EventArgs e)
        {
            Array attributes = _tc.GetAllAttributes();

            dgv.Columns[dgv.Columns.IndexOf(ColumnPreview)].DefaultCellStyle.BackColor = buttonBackColor.BackColor;
            int i = 0;
            foreach (MutableString attr in attributes) 
            {
                dgv.Rows.Add();
                UpdateDGVRow(dgv.Rows[i], (string)attr);
                i++;
            }
        }

        private void UpdateDGVRow(DataGridViewRow row, string attr)
        {
            object obj;
            row.Cells[dgv.Columns.IndexOf(ColumnFont)].Value =
            row.Cells[dgv.Columns.IndexOf(ColumnColor)].Value = null;
            row.Cells[dgv.Columns.IndexOf(ColumnAttribute)].Value = attr;
            if ((obj = GetFont(attr)) != null)
            {
                row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Value = GetFontInfoInString((Font)obj);
                row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Style.Font = (Font)obj;
                row.Cells[dgv.Columns.IndexOf(ColumnFont)].Value = SET;
            }
            Color color;
            if ((Color)(obj = GetColor(attr)) != Color.Empty)
            {
                color = (Color)obj;
                row.Cells[dgv.Columns.IndexOf(ColumnColor)].Style.BackColor = color;
                row.Cells[dgv.Columns.IndexOf(ColumnColor)].Value = SET;
                // 色だけ設定がある場合
                if (row.Cells[dgv.Columns.IndexOf(ColumnFont)].Value == null)
                {
                    row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Value = buttonDefaultFont.Text;
                    row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Style.Font = buttonDefaultFont.Font;
                }

            }
            else
            {
                color = buttonDefaultFontColor.BackColor;
            }
            row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Style.ForeColor = color;
            if ((Color)(obj = GetColor(attr + "_char")) != Color.Empty)
            {
                color = (Color)obj;
                row.Cells[dgv.Columns.IndexOf(ColumnCharColor)].Style.BackColor = color;
                row.Cells[dgv.Columns.IndexOf(ColumnCharColor)].Value = SET;
                //色だけ設定がある場合
                if (row.Cells[dgv.Columns.IndexOf(ColumnFont)].Value == null)
                {
                    row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Value = buttonDefaultFont.Text;
                    row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Style.Font = buttonDefaultFont.Font;
                }
            }
        }


        private void SaveDGVSettings()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string attr = (string)row.Cells[dgv.Columns.IndexOf(ColumnAttribute)].Value;
                if ((row.Cells[dgv.Columns.IndexOf(ColumnFont)].Value != null))
                {
                    SetFont(attr, row.Cells[dgv.Columns.IndexOf(ColumnPreview)].Style.Font);
                }
                else
                {
                    UnsetFont(attr);
                }
                if ((row.Cells[dgv.Columns.IndexOf(ColumnColor)].Value != null))
                {
                    SetColor(attr, row.Cells[dgv.Columns.IndexOf(ColumnColor)].Style.BackColor);
                }
                else
                {
                    UnsetColor(attr);
                }
                if ((row.Cells[dgv.Columns.IndexOf(ColumnCharColor)].Value != null))
                {
                    SetColor(attr + "_char", row.Cells[dgv.Columns.IndexOf(ColumnCharColor)].Style.BackColor);
                }
                else
                {
                    UnsetColor(attr + "_char");
                }
            }
        }

        private void SetFont(string attr, Font font)
        {
            FontSettings.SetFont(attr + "_font", font);
        }

        private void UnsetFont(string attr)
        {
            FontSettings.Unset(attr + "_font");
        }

        private void SetColor(string attr, Color color)
        {
            FontSettings.SetColor(attr + "_color", color);
        }

        private void UnsetColor(string attr)
        {
            FontSettings.Unset(attr + "_color");
        }

        public Font GetFont(string attr, bool insure = false)
        {
            Font font = FontSettings.GetFont(attr + "_font");
            if (insure && font == null)
            {
                font = FontSettings.GetFont("default_font");
            }
            return font;
        }

        public Color GetColor(string attr, bool insure = false)
        {
            Color color = FontSettings.GetColor(attr + "_color");
            if (insure && color == Color.Empty)
            {
                color = FontSettings.GetColor("default_fore_color");
            }
            return color;
        }

        private void buttonDefaultFont_Click(object sender, EventArgs e)
        {
            Font font = buttonDefaultFont.Font;
            if (OpenFontDialog(ref font))
            {
                buttonDefaultFont.Text = GetFontInfoInString(font);
                buttonDefaultFont.Font = font;
            }
        }

        private void buttonDefaultFontColor_Click(object sender, EventArgs e)
        {
            Color color = buttonDefaultFontColor.BackColor;
            if (OpenColorDialog(ref color))
            {
                buttonDefaultFont.ForeColor = color;
                buttonDefaultFontColor.BackColor = color;
            }
        }

        private void buttonDefaultCharColor_Click(object sender, EventArgs e)
        {
            Color color = buttonDefaultCharColor.BackColor;
            if (OpenColorDialog(ref color))
            {
                buttonDefaultCharColor.BackColor = color;
            }
        }

        private void formFontSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.formFontSettingsSize = this.ClientSize; //サイズがおかしくなるのを回避
            Properties.Settings.Default.Save();
        }

        private string GetFontInfoInString(Font font)
        {
            if (font == null) return null;
            string str = font.Name + ", " + font.SizeInPoints + "pt, " + font.Style.ToString();
            return str;
        }

        public void SetCoreInstance(tororoCoreInterface tc)
        {
            _tc = tc;
        }
        
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; // コラムヘッダのクリックは無視する
            // フォントの設定
            if (e.ColumnIndex == dgv.Columns.IndexOf(ColumnFont))
            {
                Font font = dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font;
                if (OpenFontDialog(ref font))
                {
                    dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Value = GetFontInfoInString(fontDialog.Font);
                    dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font = font;
                    dgv[e.ColumnIndex, e.RowIndex].Value = SET;
                    dgv[e.ColumnIndex, e.RowIndex].ToolTipText = font.ToString();
                }
            }
            // 色の設定
            else if (e.ColumnIndex == dgv.Columns.IndexOf(ColumnColor))
            {
                Color color = dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.ForeColor;
                if (OpenColorDialog(ref color))
                {
                    dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.ForeColor = color;
                    dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = color;
                    dgv[e.ColumnIndex, e.RowIndex].Value = SET;
                    dgv[e.ColumnIndex, e.RowIndex].ToolTipText = color.ToString();
                    // 色だけ設定した場合
                    if (dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font == null)
                    {
                        dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Value = buttonDefaultFont.Text;
                        dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font = buttonDefaultFont.Font;
                    }
                }
                // フォーカスが邪魔なので先頭に飛ばす
                dgv.CurrentCell = dgv[0, e.RowIndex];
            }
            else if (e.ColumnIndex == dgv.Columns.IndexOf(ColumnCharColor))
            {
                Color char_color = dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.ForeColor;
                if (OpenColorDialog(ref char_color))
                {
                    dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = char_color;
                    dgv[e.ColumnIndex, e.RowIndex].Value = SET;
                    dgv[e.ColumnIndex, e.RowIndex].ToolTipText = char_color.ToString();
                    // キャラ名の色だけ設定した場合
                    if (dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font == null)
                    {
                        dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Value = buttonDefaultFont.Text;
                        dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font = buttonDefaultFont.Font;
                    }
                }
                // フォーカスが邪魔なので先頭に飛ばす
                dgv.CurrentCell = dgv[0, e.RowIndex];

            }
            // 標準に戻す
            else if (e.ColumnIndex == dgv.Columns.IndexOf(ColumnSetDefault))
            {
                dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Value = null;
                dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.Font = null;
                dgv[dgv.Columns.IndexOf(ColumnPreview), e.RowIndex].Style.ForeColor = Color.Empty;
                dgv[dgv.Columns.IndexOf(ColumnFont), e.RowIndex].Value =
                dgv[dgv.Columns.IndexOf(ColumnColor), e.RowIndex].Value =
                dgv[dgv.Columns.IndexOf(ColumnCharColor), e.RowIndex].Value = null;
                dgv[dgv.Columns.IndexOf(ColumnColor), e.RowIndex].Style.BackColor =
                dgv[dgv.Columns.IndexOf(ColumnCharColor), e.RowIndex].Style.BackColor = Color.Empty;
                _changed = true;
            }
        }

        private bool OpenFontDialog(ref Font font)
        {
            fontDialog.Font = font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog.Font;
                _changed = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool OpenColorDialog(ref Color color)
        {
            colorDialog.Color = color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                _changed = true;
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SaveDefaultSettings()
        {
            SetFont("default", buttonDefaultFont.Font);
            SetColor("default_fore", buttonDefaultFontColor.BackColor);
            SetColor("default_char", buttonDefaultCharColor.BackColor);
            SetColor("default_back", buttonBackColor.BackColor);
            SetColor("default_highlight", buttonHighlight.BackColor);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (_changed)
            {
                SaveDefaultSettings();
                SaveDGVSettings();
                FontSettings.Save();
                ((formTororo)this.Owner).Reconvert();
                _changed = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_changed)
            {
                SaveDefaultSettings();
                SaveDGVSettings();
                FontSettings.Save();
                ((formTororo)this.Owner).Reconvert();
                _changed = false;
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _changed = false;
            this.Close();
        }
    }
}
