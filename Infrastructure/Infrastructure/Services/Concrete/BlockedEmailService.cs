using Infrastructure.Enums;
using Infrastructure.Services.Abstract;

namespace Infrastructure.Services.Concrete
{
    public class BlockedEmailService : IBlockedEmailService
    {
        #region Properties
        private readonly ILogService _logService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructors
        public BlockedEmailService(ILogService logService, IUnitOfWork unitOfWork)
        {
            _logService = logService;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<bool> IsBlockedEmailConfirmedAsync(string email)
        {
            try
            {
                // Check if the email is blocked
                var blockedEmail = await _unitOfWork.BlockedEmails.GetByEmailAsync(email);

                // If the email is blocked, return true
                if (blockedEmail != null)
                    return true;

                // If the email is not blocked, return false
                return false;
            }
            catch (Exception exception)
            {
                // Log the exception
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // If an exception occurs, return true
                return true;
            }
        }

        public async Task BlockEmailAsync(string email)
        {
            try
            {
                // Check if the email is already blocked
                var blockedEmail = await _unitOfWork.BlockedEmails.GetByEmailAsync(email);

                // If the email is already blocked, return
                if (blockedEmail != null) return;

                // Block the email
                await _unitOfWork.BlockedEmails.AddAsync(new Domain.Entities.BlockedEmail() { Email = email }, CancellationToken.None);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                // Log the exception
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // If an exception occurs, return
                return;
            }
        }
        #endregion
    }
}