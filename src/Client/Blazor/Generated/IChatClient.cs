using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IChatClient
    {
        Task<IOperationResult<IPeople>> GetPeopleAsync(
            Optional<string> userId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IPeople>> GetPeopleAsync(
            GetPeopleOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            Optional<string> userId = default,
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IGetPeopleAndRecipient>> GetPeopleAndRecipientAsync(
            GetPeopleAndRecipientOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IRecipientById>> GetRecipientAsync(
            Optional<string> recipientId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IRecipientById>> GetRecipientAsync(
            GetRecipientOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISendMessage>> SendMessageAsync(
            Optional<string> recipientEmail = default,
            Optional<string> text = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISendMessage>> SendMessageAsync(
            SendMessageOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISignIn>> SignInAsync(
            Optional<LoginInput> signIn = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISignIn>> SignInAsync(
            SignInOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISignUp>> SignUpAsync(
            Optional<CreateUserInput> newUser = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<ISignUp>> SignUpAsync(
            SignUpOperation operation,
            CancellationToken cancellationToken = default);
    }
}
