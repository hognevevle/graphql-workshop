using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IPerson
    {
        System.Guid Id { get; }

        string Name { get; }

        string Email { get; }

        System.DateTimeOffset LastSeen { get; }
    }
}
