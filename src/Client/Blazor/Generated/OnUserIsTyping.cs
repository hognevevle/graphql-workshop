using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class OnUserIsTyping
        : IOnUserIsTyping
    {
        public OnUserIsTyping(
            IHasPersonId onTyping)
        {
            OnTyping = onTyping;
        }

        public IHasPersonId OnTyping { get; }
    }
}
