using Application.Wrappers;
using Infrastructure.Models;
using Persistence.Parameters.Concrete;

namespace Infrastructure.Services.Abstract
{
    public interface IUserService
    {
        #region Signatures
        /// <summary>
        /// Insert a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ModelResponse<UserModel>> InsertAsync(UserModel model);

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ModelResponse<UserModel>> UpdateAsync(UserModel model);

        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ModelResponse<UserModel>> DeleteAsync(UserModel model);

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ModelResponse<UserModel>> GetByIdAsync(int id);

        /// <summary>
        /// Get a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<ModelResponse<UserModel>> GetByEmailAsync(string email);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        Task<ModelResponse<IEnumerable<UserModel>>> GetAllAsync();

        /// <summary>
        /// Get all users by parameters
        /// </summary>
        /// <returns></returns>
        Task<PagedModelResponse<IEnumerable<UserModel>>> GetAllByParametersAsync(ListRequestParameter parameter);
        #endregion
    }
}