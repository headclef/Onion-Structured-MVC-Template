namespace Application.Wrappers
{
    public class Response<T> where T : class
    {
        #region Properties
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; } = null!;
        public Error Error { get; set; } = new Error();
        #endregion
    }
}