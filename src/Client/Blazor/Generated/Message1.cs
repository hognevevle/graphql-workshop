﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class Message1
        : IMessage1
    {
        public Message1(
            System.DateTimeOffset sent)
        {
            Sent = sent;
        }

        public System.DateTimeOffset Sent { get; }
    }
}
