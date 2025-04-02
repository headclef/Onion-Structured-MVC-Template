using Infrastructure.Enums;

namespace Infrastructure.Services.Abstract
{
    public interface ILogService
    {
        #region Signatures
        /// <summary>
        /// Writes message to log file depending on log type
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        void WriteLog(LogLevel logLevel, string message);
        #endregion
    }
}