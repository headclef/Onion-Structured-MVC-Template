using Application.Repositories.Abstract.Common;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Repositories.Abstract
{
    // IBlockedEmailRepository inherits from IBaseRepository<BlockedEmail>
    public interface IBlockedEmailRepository : IBaseRepository<BlockedEmail> 
    {
        /// <summary>
        /// This method is used to get a blocked email by its email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<ModelResponse<BlockedEmail>> GetByEmailAsync(string email);
    }
}