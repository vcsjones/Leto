﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal partial class Interop
{
    internal partial class LibCrypto
    {
        [DllImport(Libraries.LibCrypto, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe int EVP_DigestSignInit(EVP_MD_CTX ctx, EVP_PKEY_CTX* pctx, IntPtr type, IntPtr engine, EVP_PKEY pkey);
    }
}