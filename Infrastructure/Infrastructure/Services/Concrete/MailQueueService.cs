using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Services.Abstract;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services.Concrete
{
    public class MailQueueService : BackgroundService
    {
        #region Properties
        private readonly IMailQueue _mailQueue;
        private readonly IMailService _mailService;
        private readonly IBlockedEmailService _blockedEmailService;
        private readonly ILogService _logService;
        #endregion
        #region Constructors
        public MailQueueService(IMailQueue mailQueue, IMailService mailService, IBlockedEmailService blockedEmailService, ILogService logService)
        {
            _mailQueue = mailQueue;
            _mailService = mailService;
            _blockedEmailService = blockedEmailService;
            _logService = logService;
        }
        #endregion
        #region Methods
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Dequeue an email
                var email = await _mailQueue.DequeueAsync(stoppingToken);

                // If email is null or it's blocked, continue
                if (email is null || await _blockedEmailService.IsBlockedEmailConfirmedAsync(email.To)) continue;

                // Try to send the email
                bool success = await TrySendEmailAsync(email);

                if (success)
                    // If the email is sent, log the information
                    _logService.WriteLog(LogLevel.Information, $"Email sent successfully to {email.To} at {DateTime.Now:mm.HH.dd.MM.yyyy}.");
                else
                {
                    // If the email fails to send, log the information and block the email
                    _logService.WriteLog(LogLevel.Error, $"Email failed to send to {email.To} at {DateTime.Now:mm.HH.dd.MM.yyyy} and decided that it's a spam mail so it's blocked.");

                    // Block the email
                    await _blockedEmailService.BlockEmailAsync(email.To);
                }

                // Wait for 5 minutes
                await Task.Delay(60000, stoppingToken);
            }
        }

        private async Task<bool> TrySendEmailAsync(QueuedMailModel email)
        {
            try
            {
                // Send the email
                await _mailService.SendEmailAsync(email.To, email.Type, email.Placeholders);

                // Log the success
                return true;
            }
            catch (Exception exception)
            {
                // Log the exception
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // If the email fails to send, try only once more
                try
                {
                    await _mailService.SendEmailAsync(email.To, email.Type, email.Placeholders);
                    return true;
                }
                catch (Exception innerException)
                {
                    // Log the inner exception
                    _logService.WriteLog(LogLevel.Error, innerException.Message);
                    return false;
                }
            }
        }
        #endregion
    }
}