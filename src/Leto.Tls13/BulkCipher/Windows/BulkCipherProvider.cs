﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leto.Tls13.Internal;
using Leto.Tls13.Interop.Windows;
using Microsoft.Win32.SafeHandles;
using static Interop.BCrypt;

namespace Leto.Tls13.BulkCipher.Windows
{
    public class BulkCipherProvider : IBulkCipherProvider
    {
        private static readonly int _bufferSize = 12;
        private readonly SecureBufferPool _bufferPool = new SecureBufferPool(_bufferSize, 10000);

        private SafeBCryptAlgorithmHandle _aesProvider;

        public BulkCipherProvider()
        {
            Interop.Windows.ExceptionHelper.CheckReturnCode(BCryptOpenAlgorithmProvider(out _aesProvider, "AES", "", BCryptOpenAlgorithmProviderFlags.None));
        }

        public IBulkCipherInstance GetCipherKey(BulkCipherType cipher)
        {
            if (cipher == BulkCipherType.AES_128_GCM || cipher == BulkCipherType.AES_256_GCM)
            {
                return new AeadBulkCipherInstance(_aesProvider, _bufferPool, cipher);
            }
            return null;
        }

        public void Dispose()
        {
            _bufferPool.Dispose();
            GC.SuppressFinalize(this);
        }

        ~BulkCipherProvider()
        {
            Dispose();
        }
    }
}
