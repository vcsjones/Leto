// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.Win32.SafeHandles;

internal partial class Interop
{
    internal partial class BCrypt
    {
        [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
        internal static extern NTSTATUS BCryptFinishHash(SafeBCryptHashHandle hHash, [Out] byte[] pbOutput, int cbOutput, int dwFlags);
        [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
        internal static extern NTSTATUS BCryptFinishHash(SafeBCryptHashHandle hHash, IntPtr pbOutput, int cbOutput, int dwFlags);
    }
}

