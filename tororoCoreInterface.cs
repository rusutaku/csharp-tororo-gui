using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronRuby.Builtins;

namespace tororo_gui
{
    public class tororoCoreInterface
    {

        IronRubyScriptEngine _ire;

        public tororoCoreInterface()
        {
            _ire = new IronRubyScriptEngine();
            _ire.ExecuteFile("tororo.rb");
            _ire.Invoke("t = Tororo.new");
        }

        public string ConvertLog(string filepath)
        {
            return CorrectCode((String)_ire.Invoke("t.conv_from_log('" + filepath + "')").ToString());
        }

        public string ContinueConvert()
        {
            return CorrectCode((String)_ire.Invoke("t.conv_continue").ToString());
        }

        // 文字化けを直す
        private string CorrectCode(string broken)
        {
            byte[] b, r;
            string corr;
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
            corr = Encoding.Unicode.GetString(r); // 文字列に変換
            return corr;
        }
        
        public bool GetCharacterNameOffset(int num, ref int begin, ref int end)
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

        public string GetLineAttribute(int num)
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

        public int GetProcessedLineNum()
        {
            return (int)_ire.Invoke("t.count");
        }

        public string GetVersion()
        {
            return _ire.Invoke("t.version").ToString();
        }

        public Array GetAllAttributes()
        {
            return ((RubyArray)_ire.Invoke("t.get_all_attributes")).ToArray();
        }

        public Array GetFilters(string attribute)
        {
            return ((RubyArray)_ire.Invoke("t.get_filters('" + attribute + "')")).ToArray();
        }

        public Hash GetAttributesHashtable()
        {
            object h;
            h = _ire.Invoke("t.get_attributes_hashtable");
            return (Hash)h;
        }
    }
}
