using System;

namespace ProjetoEstacio.Model
{
    public class CustomException : Exception
    {
        public string ErrorMessage { get; }
        public string ErrorCode { get; }

        public CustomException(string message, string errorCode) 
            : base(message)
        {
            ErrorMessage = message;
            ErrorCode = errorCode;
        }
    }
}