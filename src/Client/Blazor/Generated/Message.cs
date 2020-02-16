using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Message
        : IMessage
    {
        public Message(
            Direction direction, 
            System.Guid id, 
            IParticipant recipient, 
            IParticipant sender, 
            System.DateTimeOffset sent, 
            string text)
        {
            Direction = direction;
            Id = id;
            Recipient = recipient;
            Sender = sender;
            Sent = sent;
            Text = text;
        }

        public Direction Direction { get; }

        public System.Guid Id { get; }

        public IParticipant Recipient { get; }

        public IParticipant Sender { get; }

        public System.DateTimeOffset Sent { get; }

        public string Text { get; }
    }
}
