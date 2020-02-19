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

        public Task<IOperationResult<IGetPeople>> GetPeopleAsync(
            Optional<System.Guid> userId = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetPeopleOperation { UserId = userId },
                cancellationToken);
        }

        public Task<IOperationResult<IGetPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ILoadChat>> LoadChatAsync(
            Optional<System.Guid> recipientId = default,
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new LoadChatOperation { RecipientId = recipientId },
                cancellationToken);
        }

        public Task<IOperationResult<ILoadChat>> LoadChatAsync(
            LoadChatOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ISignin>> SigninAsync(
            Optional<LoginInput> input = default,
            CancellationToken cancellationToken = default)
        {
            if (input.HasValue && input.Value is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return _executor.ExecuteAsync(
                new SigninOperation { Input = input },
                cancellationToken);
        }

        public Task<IOperationResult<ISignin>> SigninAsync(
            SigninOperation operation,
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
