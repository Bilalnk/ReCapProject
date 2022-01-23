namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(true, data)
        {
        }

        public SuccessDataResult(string message, T data) : base(true, message, data)
        {
        }

        public SuccessDataResult() : base(true)
        {
        }

        public SuccessDataResult(string message) : base(true, message, default)
        {
        }
    }
}