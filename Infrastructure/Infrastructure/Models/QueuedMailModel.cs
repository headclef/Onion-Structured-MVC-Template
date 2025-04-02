using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class QueuedMailModel
    {
        #region Properties
        public string To { get; set; }
        public EmailType Type { get; set; }
        public Dictionary<string, string> Placeholders { get; set; }
        #endregion
    }
}