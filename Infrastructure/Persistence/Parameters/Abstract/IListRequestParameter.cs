namespace Persistence.Parameters.Abstract
{
    public interface IListRequestParameter
    {
        #region Properties
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        #endregion
    }
}