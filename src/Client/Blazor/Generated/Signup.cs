using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SignUp
        : ISignUp
    {
        public SignUp(
            ICreateUserPayload createUser)
        {
            CreateUser = createUser;
        }

        public ICreateUserPayload CreateUser { get; }
    }
}
