﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leto.Tls13.KeyExchange.OpenSsl11
{
    public class KeyShareProvider : IKeyShareProvider
    {
        public IKeyShareInstance GetKeyShareInstance(NamedGroup namedGroup)
        {
            switch(namedGroup)
            {
                case NamedGroup.ffdhe2048:
                case NamedGroup.ffdhe3072:
                case NamedGroup.ffdhe4096:
                case NamedGroup.ffdhe6144:
                case NamedGroup.ffdhe8192:
                    return new FiniteFieldInstance();
                case NamedGroup.secp256r1:
                case NamedGroup.secp384r1:
                case NamedGroup.secp521r1:
                    return new ECCurveInstance();
                case NamedGroup.x25519:
                case NamedGroup.x448:
                    return new ECFunctionInstance(namedGroup);
                default:
                    return null;
            }
        }
    }
}