using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IMessage
    {
        Direction Direction { get; }

        string Id { get; }

        IParticipant Recipient { get; }

        IParticipant Sender { get; }

        System.DateTimeOffset Sent { get; }

        string Text { get; }
    }
}
