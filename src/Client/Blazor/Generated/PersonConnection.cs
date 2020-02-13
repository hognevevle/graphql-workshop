using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class PersonConnection
        : IPersonConnection
    {
        public PersonConnection(
            IReadOnlyList<IPerson1> nodes)
        {
            Nodes = nodes;
        }

        public IReadOnlyList<IPerson1> Nodes { get; }
    }
}
