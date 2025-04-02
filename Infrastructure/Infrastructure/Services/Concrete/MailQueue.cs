using Infrastructure.Models;
using Infrastructure.Services.Abstract;
using System.Collections.Concurrent;

namespace Infrastructure.Services.Concrete
{
    public class MailQueue : IMailQueue
    {
        #region Properties
        private readonly ConcurrentQueue<QueuedMailModel> _queue = new();
        private readonly SemaphoreSlim _signal = new(0);
        #endregion
        #region Methods
        public void Enqueue(QueuedMailModel email)
        {
            // Enqueue the email
            _queue.Enqueue(email);

            // Release a signal
            _signal.Release();
        }

        public async Task<QueuedMailModel?> DequeueAsync(CancellationToken cancellationToken)
        {
            // Wait for a signal to be released
            await _signal.WaitAsync(cancellationToken);

            // Try to dequeue an email
            _queue.TryDequeue(out var email);

            // Return the email
            return email;
        }
        #endregion
    }
}