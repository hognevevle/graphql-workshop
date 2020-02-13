﻿using System;
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
            string name, 
            string email, 
            System.DateTimeOffset lastSeen)
        {
            Id = id;
            Name = name;
            Email = email;
            LastSeen = lastSeen;
        }

        public System.Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public System.DateTimeOffset LastSeen { get; }
    }
}
