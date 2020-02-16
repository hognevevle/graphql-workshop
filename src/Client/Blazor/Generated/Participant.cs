using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Participant
        : IParticipant
    {
        public Participant(
            System.Guid id, 
            string name, 
            bool isOnline)
        {
            Id = id;
            Name = name;
            IsOnline = isOnline;
        }

        public System.Guid Id { get; }

        public string Name { get; }

        public bool IsOnline { get; }
    }
}
