﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal partial class Interop
{
    internal partial class LibCrypto
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct DH
        {
            private IntPtr _ptr;

            public bool IsAllocated => _ptr != IntPtr.Zero;

            public void Free()
            {
                DH_free(_ptr);
                _ptr = IntPtr.Zero;
            }
        }
    }
}
