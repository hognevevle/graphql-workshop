using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class InitialDataOperation
        : IOperation<IInitialData>
    {
        public string Name => "initialData";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IInitialData);

        public Optional<System.Guid> UserId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (UserId.HasValue)
            {
                variables.Add(new VariableValue("userId", "Uuid", UserId.Value));
            }

            return variables;
        }
    }
}
