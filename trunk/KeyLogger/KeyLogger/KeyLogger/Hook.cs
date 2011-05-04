using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Hooks
{
    public abstract class Hook
    {
        protected Win32.HookTypes hookType;
        protected Win32.HookProc hookProcedure;
        protected IntPtr hndlHook;

        public Hook(Win32.HookTypes hookType)
        {
            this.hookType = hookType;
            this.hookProcedure = new Win32.HookProc(HookProcedure);
        }

        public void Install()
        {
            hndlHook = Win32.SetWindowsHookEx(hookType, HookProcedure, Marshal.GetHINSTANCE(this.GetType().Module), 0);
        }

        public void Uninstall()
        {
            Win32.UnhookWindowsHookEx(hndlHook);
        }

        protected abstract int HookProcedure(int code, IntPtr wParam, IntPtr lParam);
    }
}
