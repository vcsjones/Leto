﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal partial class Interop
{
    internal partial class LibCrypto
    {
        [DllImport(Libraries.LibCrypto, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe int EVP_CIPHER_CTX_ctrl(EVP_CIPHER_CTX ctx, EVP_CIPHER_CTRL type, int arg, void* ptr);
    }
}
