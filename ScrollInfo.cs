using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace tororo_gui
{
    public partial class formTororo : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        const int EM_SETSCROLLPOS = 0x0400 + 222;

        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, POINT lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        private enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        private bool IsEndOfScroll()
        {
            SCROLLINFO SCInfo = new SCROLLINFO();

            SCInfo.cbSize = (uint)Marshal.SizeOf(SCInfo);     //この２行は必須
            SCInfo.fMask  = (int)ScrollInfoMask.SIF_ALL;

            GetScrollInfo(rTextBoxOut.Handle, (int)ScrollBarDirection.SB_VERT, ref SCInfo);
            if (SCInfo.nPos >= SCInfo.nMax - Math.Max(SCInfo.nPage, 0))
            {
                return true;
            }
            return false;
        }

        private void ScrollToEnd(ref RichTextBox tbb)
        {
            //tbb.SelectionStart = tbb.Text.Length;
            //tbb.ScrollToCaret();

            //なんかずれる ScrollToCaret() の代わりにスクロール
            //http://www.dutton.me.uk/2011/08/31/richtextbox-scrolltocaret-bug/
            //int min, max;
            //GetScrollRange(rTextBoxOut.Handle, (int)ScrollBarDirection.SB_VERT, out min, out max);
            SCROLLINFO SCInfo = GetScrollInfoStruct(tbb);
            SendMessage(tbb.Handle, EM_SETSCROLLPOS, 0, new POINT(0, SCInfo.nMax - tbb.Height));
        }

        private int GetScrollPos(RichTextBox tbb)
        {
            SCROLLINFO SCInfo = GetScrollInfoStruct(tbb);
            return SCInfo.nPos;
        }

        private void SetScrollPos(ref RichTextBox tbb, int pos)
        {
            SendMessage(tbb.Handle, EM_SETSCROLLPOS, 0, new POINT(0, pos));
        }

        private SCROLLINFO GetScrollInfoStruct(RichTextBox tbb)
        {
            SCROLLINFO SCInfo = new SCROLLINFO();

            SCInfo.cbSize = (uint)Marshal.SizeOf(SCInfo);     //この２行は必須
            SCInfo.fMask = (int)ScrollInfoMask.SIF_ALL;

            GetScrollInfo(tbb.Handle, (int)ScrollBarDirection.SB_VERT, ref SCInfo);
            return SCInfo;
        }


    }
}
