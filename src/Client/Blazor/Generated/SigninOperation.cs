using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SignInOperation
        : IOperation<ISignIn>
    {
        public string Name => "signIn";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ISignIn);

        public Optional<LoginInput> SignIn { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (SignIn.HasValue)
            {
                variables.Add(new VariableValue("signIn", "LoginInput", SignIn.Value));
            }

            return variables;
        }
    }
}
