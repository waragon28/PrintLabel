﻿using System;
using System.Collections.Generic;
using System.Linq;


using System.Runtime.InteropServices;

namespace Forxap.Framework.UI
{
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        private IntPtr handle;

        public virtual IntPtr Handle
        {
            get
            {
                return handle;
            }
        }

        public WindowWrapper(IntPtr handle)
        {
            this.handle = handle;
        }

        public static WindowWrapper GetForegroundWindowWrapper()
        {
            return new WindowWrapper(GetForegroundWindow());
        }
    }
}