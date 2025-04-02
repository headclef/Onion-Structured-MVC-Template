using Application.Dtos;
using Application.Repositories.Abstract;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Concrete.Common;

namespace Persistence.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Properties
        private readonly BaseDbContext _dbContext;
        #endregion
        #region Constructors
        public UserRepository(BaseDbContext dbContext) : base(dbContext) { _dbContext = dbContext; }
        public async Task<ModelResponse<UserDto>> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            // Get user by email
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            // Check if user is null
            if (user is null)
                return new ModelResponse<UserDto>().Success();

            // Return success response
            return new ModelResponse<UserDto>().Success(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }
        #endregion
    }
}