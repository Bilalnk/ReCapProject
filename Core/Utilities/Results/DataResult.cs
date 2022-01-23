namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }

        public DataResult(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        public DataResult(bool success) : base(success)
        {
        }

        public DataResult(bool success, string message) : base(success, message)
        {
        }

        public T Data { get; }
    }
}