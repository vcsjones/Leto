﻿using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Leto.Tls13.RecordLayer;

namespace Leto.Tls13.BulkCipher
{
    public interface IBulkCipherInstance:IDisposable
    {
        int Overhead { get; }
        int KeyLength { get; }
        int IVLength { get; }
        void SetKey(Span<byte> key);
        void SetIV(Span<byte> iv);
        void Decrypt(ref ReadableBuffer messageBuffer);
        void Encrypt(ref WritableBuffer buffer, ReadableBuffer plainText, RecordType recordType);
        void WithPadding(int paddingSize);
        void Encrypt(ref WritableBuffer buffer, Span<byte> plainText, RecordType recordType);
    }
}
