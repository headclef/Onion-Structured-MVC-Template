using Persistence.Parameters.Abstract;

namespace Persistence.Parameters.Concrete
{
    public class ListRequestParameter : IListRequestParameter
    {
        #region Properties
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public string? Search { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public string? SortOrder { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        #endregion
    }
}