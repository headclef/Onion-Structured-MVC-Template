using Application.Repositories.Abstract;

namespace Infrastructure.Services.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        #region Properties
        IUserRepository Users { get; }
        IBlockedEmailRepository BlockedEmails { get; }
        #endregion
        #region Signatures
        /// <summary>
        /// Save the changes to the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion
    }
}