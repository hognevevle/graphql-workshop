using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessagePayload
        : ISendMessagePayload
    {
        public SendMessagePayload(
            global::Client.IMessage1 message)
        {
            Message = message;
        }

        public global::Client.IMessage1 Message { get; }
    }
}
