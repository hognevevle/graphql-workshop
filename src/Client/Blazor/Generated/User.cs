using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class User
        : IUser
    {
        public User(
            System.Guid id, 
            string name, 
            string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public System.Guid Id { get; }

        public string Name { get; }

        public string Email { get; }
    }
}
