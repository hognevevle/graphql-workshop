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

        public Task<IOperationResult<IPeople>> GetPeopleAsync(
            Optional<string> userId = default,
            CancellationToken cancellationToken = default)
        {
            if (userId.HasValue && userId.Value is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _executor.ExecuteAsync(
                new GetPeopleOperation { UserId = userId },
                cancellationToken);
        }

        public Task<IOperationResult<IPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            Optional<string> userId = default,
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default)
        {
            if (userId.HasValue && userId.Value is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (recipientId.HasValue && recipientId.Value is null)
            {
                throw new ArgumentNullException(nameof(recipientId));
            }

            return _executor.ExecuteAsync(
                new GetPeopleAndRecipientOperation
                {
                    UserId = userId, 
                    RecipientId = recipientId
                },
                cancellationToken);
        }

        public Task<IOperationResult<IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            GetPeopleAndRecipientOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IRecipientById>> GetRecipientAsync(
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default)
        {
            if (recipientId.HasValue && recipientId.Value is null)
            {
                throw new ArgumentNullException(nameof(recipientId));
            }

            return _executor.ExecuteAsync(
                new GetRecipientOperation { RecipientId = recipientId },
                cancellationToken);
        }

        public Task<IOperationResult<IRecipientById>> GetRecipientAsync(
            GetRecipientOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ISendMessage>> SendMessageAsync(
            Optional<string> recipientEmail = default,
            Optional<string> text = default,
            CancellationToken cancellationToken = default)
        {
            if (recipientEmail.HasValue && recipientEmail.Value is null)
            {
                throw new ArgumentNullException(nameof(recipientEmail));
            }

            if (text.HasValue && text.Value is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return _executor.ExecuteAsync(
                new SendMessageOperation
                {
                    RecipientEmail = recipientEmail, 
                    Text = text
                },
                cancellationToken);
        }

        public Task<IOperationResult<ISendMessage>> SendMessageAsync(
            SendMessageOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ISignIn>> SignInAsync(
            Optional<LoginInput> signIn = default,
            CancellationToken cancellationToken = default)
        {
            if (signIn.HasValue && signIn.Value is null)
            {
                throw new ArgumentNullException(nameof(signIn));
            }

            return _executor.ExecuteAsync(
                new SignInOperation { SignIn = signIn },
                cancellationToken);
        }

        public Task<IOperationResult<ISignIn>> SignInAsync(
            SignInOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<ISignUp>> SignUpAsync(
            Optional<CreateUserInput> newUser = default,
            CancellationToken cancellationToken = default)
        {
            if (newUser.HasValue && newUser.Value is null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            return _executor.ExecuteAsync(
                new SignUpOperation { NewUser = newUser },
                cancellationToken);
        }

        public Task<IOperationResult<ISignUp>> SignUpAsync(
            SignUpOperation operation,
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
