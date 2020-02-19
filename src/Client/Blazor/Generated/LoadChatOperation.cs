using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class LoadChatOperation
        : IOperation<ILoadChat>
    {
        public string Name => "loadChat";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(ILoadChat);

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
