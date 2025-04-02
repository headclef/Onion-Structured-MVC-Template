using Application.Repositories.Abstract;
using Application.Wrappers;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Concrete.Common;

namespace Persistence.Repositories.Concrete
{
    public class BlockedEmailRepository : BaseRepository<BlockedEmail>, IBlockedEmailRepository
    {
        #region Constructors
        public BlockedEmailRepository(BaseDbContext dbContext) : base(dbContext) { }
        #endregion
        #region Methods
        public async Task<ModelResponse<BlockedEmail>> GetByEmailAsync(string email)
        {
            // Get the blocked email by email
            var emails = await base.GetAllAsync();

            // If the email is not found, return a fail response
            if (!emails.IsSuccess)
                return new ModelResponse<BlockedEmail>().Fail("Belirtilen e-posta adresi bulunamadı.");

            // Return the blocked email
            var blockedEmail = emails.Data.FirstOrDefault(x => x.Email == email);

            // If the blocked email is not found, return a fail response
            if (blockedEmail == null)
                return new ModelResponse<BlockedEmail>().Fail("Belirtilen e-posta adresi bulunamadı.");

            // Return the blocked email
            return new ModelResponse<BlockedEmail>().Success(blockedEmail);
        }
        #endregion
    }
}