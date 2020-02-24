using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SendMessage1
        : ISendMessage
    {
        public SendMessage1(
            ISendMessagePayload sendMessage)
        {
            SendMessage = sendMessage;
        }

        public ISendMessagePayload SendMessage { get; }
    }
}
