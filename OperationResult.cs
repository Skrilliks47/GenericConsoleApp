namespace GenericConsoleApp
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResult<T> Success(T value)
        {
            return new OperationResult<T>
            {
                IsSuccess = true,
                Value = value,
                ErrorMessage = null
            };
        }

        public static OperationResult<T> Failure(string errorMessage)
        {
            return new OperationResult<T>
            {
                IsSuccess = false,
                Value = default,
                ErrorMessage = errorMessage
            };
        }
    }
}