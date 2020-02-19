using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SigninOperation
        : IOperation<ISignin>
    {
        public string Name => "signin";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ISignin);

        public Optional<LoginInput> Input { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Input.HasValue)
            {
                variables.Add(new VariableValue("input", "LoginInput", Input.Value));
            }

            return variables;
        }
    }
}
