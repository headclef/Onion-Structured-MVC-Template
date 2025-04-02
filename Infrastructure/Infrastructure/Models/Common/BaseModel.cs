namespace Infrastructure.Models.Common
{
    public class BaseModel
    {
        #region Properties
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        #endregion
    }
}