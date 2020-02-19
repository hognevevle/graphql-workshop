using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class LoadChat
        : ILoadChat
    {
        public LoadChat(
            IRecipient personById)
        {
            PersonById = personById;
        }

        public IRecipient PersonById { get; }
    }
}
