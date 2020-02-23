using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class GetPeopleAndRecipient
        : IGetPeopleAndRecipient
    {
        public GetPeopleAndRecipient(
            IPersonConnection people, 
            IRecipient personById)
        {
            People = people;
            PersonById = personById;
        }

        public IPersonConnection People { get; }

        public IRecipient PersonById { get; }
    }
}
