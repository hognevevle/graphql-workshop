using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Recipient
        : IRecipient
    {
        public Recipient(
            IMessageConnection messages, 
            System.Guid id, 
            string name, 
            string email, 
            System.Uri imageUri, 
            bool isOnline, 
            System.DateTimeOffset lastSeen)
        {
            Messages = messages;
            Id = id;
            Name = name;
            Email = email;
            ImageUri = imageUri;
            IsOnline = isOnline;
            LastSeen = lastSeen;
        }

        public IMessageConnection Messages { get; }

        public System.Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public System.Uri ImageUri { get; }

        public bool IsOnline { get; }

        public System.DateTimeOffset LastSeen { get; }
    }
}
