using System;

namespace CSharpKoans.Core
{
    public abstract class KoanResult
    {

        public string Message { get; set; }

    }

    public class Success : KoanResult
    {
        public Success(string successMessage)
        {
            Message = successMessage;
        }
    }

    public class Failure : KoanResult
    {
        public Exception Exception { get; set; }
        public Failure(string failureMessage, Exception e)
        {
            Message = failureMessage;
            Exception = e;
        }
    }
}
