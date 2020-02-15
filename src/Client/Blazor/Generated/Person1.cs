using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Person1
        : IPerson1
    {
        public Person1(
            IMessageConnection messages)
        {
            Messages = messages;
        }

        public IMessageConnection Messages { get; }
    }
}
