using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Queries
        : IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            109,
            81,
            111,
            109,
            74,
            70,
            49,
            112,
            120,
            110,
            56,
            47,
            84,
            109,
            112,
            82,
            112,
            113,
            105,
            106,
            121,
            103,
            61,
            61
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            109,
            101,
            32,
            123,
            32,
            109,
            101,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            125,
            32,
            125,
            32,
            113,
            117,
            101,
            114,
            121,
            32,
            112,
            101,
            111,
            112,
            108,
            101,
            32,
            123,
            32,
            112,
            101,
            111,
            112,
            108,
            101,
            40,
            119,
            104,
            101,
            114,
            101,
            58,
            32,
            123,
            32,
            101,
            109,
            97,
            105,
            108,
            95,
            110,
            111,
            116,
            58,
            32,
            34,
            102,
            111,
            111,
            64,
            98,
            97,
            114,
            46,
            99,
            111,
            109,
            34,
            32,
            125,
            41,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            110,
            111,
            100,
            101,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            101,
            109,
            97,
            105,
            108,
            32,
            125,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query me {
              me {
                id
                name
              }
            }
            
            query people {
              people(where: { email_not: ""foo@bar.com"" }) {
                nodes {
                  email
                }
              }
            }";
    }
}
