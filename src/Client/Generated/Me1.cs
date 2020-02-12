using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Me1
        : IMe
    {
        public Me1(
            IPerson me)
        {
            Me = me;
        }

        public IPerson Me { get; }
    }
}
