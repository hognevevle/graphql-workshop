using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class GetPeople
        : IGetPeople
    {
        public GetPeople(
            IPersonConnection people)
        {
            People = people;
        }

        public IPersonConnection People { get; }
    }
}
