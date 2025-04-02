using Application.Dtos;
using Application.Repositories.Abstract.Common;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Repositories.Abstract
{
    // IUserRepository inherits from IBaseRepository<User>
    public interface IUserRepository : IBaseRepository<User> 
    {
        #region Signatures
        /// <summary>
        /// Get a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<ModelResponse<UserDto>> GetByEmailAsync(string email, CancellationToken cancellationToken);
        #endregion
    }
}