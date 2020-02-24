using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SendMessagePayload
        : ISendMessagePayload
    {
        public SendMessagePayload(
            IMessage1 message)
        {
            Message = message;
        }

        public IMessage1 Message { get; }
    }
}
