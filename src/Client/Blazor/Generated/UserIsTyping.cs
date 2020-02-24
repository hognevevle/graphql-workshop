using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class UserIsTyping
        : IUserIsTyping
    {
        public UserIsTyping(
            ITypingPayload typing)
        {
            Typing = typing;
        }

        public ITypingPayload Typing { get; }
    }
}
