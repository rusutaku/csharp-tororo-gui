using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace tororo_gui
{
    // フォント設定ファイル名："font.xml"
    // その他設定ファイル名：　"general.xml"
    class guiSettings
    {
        HashtableSerailizable _htSettings = new HashtableSerailizable();
        string _filename;

        public guiSettings(string filename)
        {
            _filename = filename;
        }

        public void LoadSettings()
        {
            if (!File.Exists(_filename))
            {
                return;
            }
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(_filename, settings);
            try
            {
                _htSettings.ReadXml(reader);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            reader.Close();
        }

        public void Save()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            XmlWriter writer = XmlWriter.Create(_filename, settings);
            _htSettings.WriteXml(writer);
            writer.Close();
        }

        public bool IsEmpty()
        {
            return _htSettings.Count == 0;
        }

        public object Get(string key)
        {
            return _htSettings[key];
        }

        public void Set(string key, Object value)
        {
            // Add だとすでに存在する場合不具合が起きる
            _htSettings[key] = value;
        }

        public void Unset(string key)
        {
            _htSettings.Remove(key);
        }

        public object GetCorrectly(string key, TypeCode type,  object init_value = null)
        {
            try
            {
                object ret;
                ret = Convert.ChangeType(_htSettings[key], type);
                return ret;
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine(key + " に対応する値は空です．", e);
            }

            return init_value;
        }

        public Font GetFont(string key, Font init = null)
        {
            // http://bytes.com/topic/c-sharp/answers/236995-convert-string-font
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
            object ret;
            if (_htSettings[key] == null)
            {
                ret = null;
            }
            else
            {
                ret = (Font)tc.ConvertFrom(_htSettings[key]);
            }
            return (Font)ret;
        }

        public Color GetColor(string key)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Color));
            object ret;
            if (_htSettings[key] == null)
            {
                ret = Color.Empty;
            }
            else
            {
                ret = (Color)tc.ConvertFrom(_htSettings[key]);
            }
            return (Color)ret;
        }

        public void SetFont(string key, Font font)
        {
            FontConverter fc = new FontConverter();
            _htSettings[key] = fc.ConvertToString(font);
        }

        public void SetColor(string key, Color color)
        {
            ColorConverter fc = new ColorConverter();
            _htSettings[key] = fc.ConvertToString(color);
        }
    }
}
