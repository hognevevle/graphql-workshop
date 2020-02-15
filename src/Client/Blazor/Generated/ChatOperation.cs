using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class ChatOperation
        : IOperation<IChat>
    {
        public string Name => "chat";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IChat);

        public Optional<System.Guid> PersonId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (PersonId.HasValue)
            {
                variables.Add(new VariableValue("personId", "Uuid", PersonId.Value));
            }

            return variables;
        }
    }
}
