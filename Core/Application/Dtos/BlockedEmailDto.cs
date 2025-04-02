using Application.Dtos.Common;

namespace Application.Dtos
{
    public class BlockedEmailDto : BaseDto
    {
        #region Properties
        public string Email { get; set; } = string.Empty;
        public int RetryCount { get; set; } = 1;
        #endregion
    }
}