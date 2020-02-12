using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class ChatClient
        : IChatClient
    {
        private const string _clientName = "ChatClient";

        private readonly IOperationExecutor _executor;

        public ChatClient(IOperationExecutorPool executorPool)
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

        public Task<IOperationResult<IPeople>> PeopleAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new PeopleOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IPeople>> PeopleAsync(
            PeopleOperation operation,
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
