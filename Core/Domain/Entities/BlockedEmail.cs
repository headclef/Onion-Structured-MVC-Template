using Domain.Entities.Common;

namespace Domain.Entities
{
    public class BlockedEmail : BaseEntity
    {
        #region Properties
        public string Email { get; set; } = string.Empty;
        public int RetryCount { get; set; } = 1;
        #endregion
    }
}