using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class GetPeopleAndRecipientOperation
        : IOperation<IGetPeopleAndRecipient>
    {
        public string Name => "getPeopleAndRecipient";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetPeopleAndRecipient);

        public Optional<System.Guid> RecipientId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (RecipientId.HasValue)
            {
                variables.Add(new VariableValue("recipientId", "Uuid", RecipientId.Value));
            }

            return variables;
        }
    }
}
