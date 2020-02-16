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
        Task<IOperationResult<IInitialData>> InitialDataAsync(
            Optional<System.Guid> userId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IInitialData>> InitialDataAsync(
            InitialDataOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IChat>> ChatAsync(
            Optional<System.Guid> personId = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IChat>> ChatAsync(
            ChatOperation operation,
            CancellationToken cancellationToken = default);
    }
}
