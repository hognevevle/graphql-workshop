using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class People1
        : IPeople
    {
        public People1(
            IPersonConnection people)
        {
            People = people;
        }

        public IPersonConnection People { get; }
    }
}
