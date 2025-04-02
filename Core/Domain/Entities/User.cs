using Domain.Entities.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        #region Properties
        public string? Username { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        #endregion
    }
}