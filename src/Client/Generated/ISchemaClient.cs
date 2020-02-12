using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Chat.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface ISchemaClient
    {
        Task<IOperationResult<IMe>> MeAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<IMe>> MeAsync(
            MeOperation operation,
            CancellationToken cancellationToken = default);
    }
}
