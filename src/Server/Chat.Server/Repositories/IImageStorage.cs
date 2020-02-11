using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server.Repositories
{
    public interface IImageStorage
    {
        Task SaveImageAsync(
            Guid userId,
            byte[] image,
            CancellationToken cancellationToken = default);

        Task<byte[]?> GetImageAsync(
            Guid userId,
            CancellationToken cancellationToken = default);
    }

    public class InMemoryImageStorage
        : IImageStorage
    {
        public Task SaveImageAsync(
            Guid userId,
            byte[] image,
            CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<byte[]?> GetImageAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Array.Empty<byte>())!;
        }
    }
}