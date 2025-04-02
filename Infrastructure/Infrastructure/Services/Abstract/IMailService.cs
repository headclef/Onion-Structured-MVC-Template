﻿using Infrastructure.Enums;

namespace Infrastructure.Services.Abstract
{
    public interface IMailService
    {
        #region Signatures
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="emailType"></param>
        /// <param name="placeholders"></param>
        /// <returns></returns>
        Task SendEmailAsync(string toEmail, EmailType emailType, Dictionary<string, string> placeholders);
        #endregion
    }
}