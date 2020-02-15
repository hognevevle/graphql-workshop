using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class MessageConnection
        : IMessageConnection
    {
        public MessageConnection(
            IReadOnlyList<IMessage> nodes)
        {
            Nodes = nodes;
        }

        public IReadOnlyList<IMessage> Nodes { get; }
    }
}
