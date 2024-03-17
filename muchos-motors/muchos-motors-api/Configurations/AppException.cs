using System;
using System.Runtime.Serialization;

namespace muchos_motors_api.Services
{
    [Serializable]
    internal class AppException : Exception
    {
        public int StatusCode { get; }
        public AppException()
        {

        }

        public AppException(string? message, int statusCode = 500) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public AppException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}