using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class OnMessageReceived
        : IOnMessageReceived
    {
        public OnMessageReceived(
            IMessage message)
        {
            Message = message;
        }

        public IMessage Message { get; }
    }
}
