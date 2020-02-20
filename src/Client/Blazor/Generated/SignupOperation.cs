using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SignupOperation
        : IOperation<ISignup>
    {
        public string Name => "signup";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ISignup);

        public Optional<CreateUserInput> NewUser { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (NewUser.HasValue)
            {
                variables.Add(new VariableValue("newUser", "CreateUserInput", NewUser.Value));
            }

            return variables;
        }
    }
}
