using System;

namespace CSharpKoans.Core
{
    public interface IKoanResult
    {
        string Message { get; set; }
    }

    public class Success : IKoanResult
    {
        public string Message { get; set; }
        public Success(string successMessage)
        {
            Message = successMessage;
        }
    }

    public class Failure : IKoanResult
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public Failure(string failureMessage, Exception e)
        {
            Message = failureMessage;
            Exception = e;
        }
    }
}
