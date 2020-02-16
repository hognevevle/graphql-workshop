using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
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

        public Task<IOperationResult<IInitialData>> InitialDataAsync(
            Optional<System.Guid> userId = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new InitialDataOperation { UserId = userId },
                cancellationToken);
        }

        public Task<IOperationResult<IInitialData>> InitialDataAsync(
            InitialDataOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IChat>> ChatAsync(
            Optional<System.Guid> personId = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new ChatOperation { PersonId = personId },
                cancellationToken);
        }

        public Task<IOperationResult<IChat>> ChatAsync(
            ChatOperation operation,
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
