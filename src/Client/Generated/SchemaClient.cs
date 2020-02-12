using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SchemaClient
        : ISchemaClient
    {
        private const string _clientName = "SchemaClient";

        private readonly IOperationExecutor _executor;

        public SchemaClient(IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public Task<IOperationResult<IMe>> MeAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new MeOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IMe>> MeAsync(
            MeOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
