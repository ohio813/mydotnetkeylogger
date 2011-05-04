using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Hooks
{
    public class Win32
    {
        public enum HookTypes
        {
            WH_MSGFILTER = -1,
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public IntPtr extraInfo;
        }

        public enum Win32Message
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
        }

        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")] 
        public static extern IntPtr SetWindowsHookEx(HookTypes hookType, HookProc proc, IntPtr hMod, int threadId);
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);


    }
}
