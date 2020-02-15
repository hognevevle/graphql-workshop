using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class InitialData
        : IInitialData
    {
        public InitialData(
            IPerson me, 
            IPersonConnection people)
        {
            Me = me;
            People = people;
        }

        public IPerson Me { get; }

        public IPersonConnection People { get; }
    }
}
