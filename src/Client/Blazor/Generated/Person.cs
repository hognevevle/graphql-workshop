using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Person
        : IPerson
    {
        public Person(
            System.Guid id, 
            string name)
        {
            Id = id;
            Name = name;
        }

        public System.Guid Id { get; }

        public string Name { get; }
    }
}
