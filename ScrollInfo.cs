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
        /*
        private int GetTororoScrollPos()
        {
            SCROLLINFO SCInfo = new SCROLLINFO();

            SCInfo.cbSize = (uint)Marshal.SizeOf(SCInfo);     //この２行は必須
            SCInfo.fMask  = (int)ScrollInfoMask.SIF_ALL;

            GetScrollInfo(rTextBoxOut.Handle, (int)ScrollBarDirection.SB_VERT, ref SCInfo);
            return SCInfo.nPos;
        }
         */

        private bool IsEndOfScroll()
        {
            SCROLLINFO SCInfo = new SCROLLINFO();

            SCInfo.cbSize = (uint)Marshal.SizeOf(SCInfo);     //この２行は必須
            SCInfo.fMask  = (int)ScrollInfoMask.SIF_ALL;

            GetScrollInfo(rTextBoxOut.Handle, (int)ScrollBarDirection.SB_VERT, ref SCInfo);
            if (SCInfo.nPos == SCInfo.nMax) return true;
            return false;
        }
    }
}
