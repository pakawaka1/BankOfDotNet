using System;
using System.Runtime.Serialization;

namespace BankOfDotNet
{
    [Serializable]
    internal class CustomerLimitException : Exception
    {
        public CustomerLimitException()
        {
        }

        public CustomerLimitException(string message) : base(message)
        {
        }

        public CustomerLimitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object NumOfCustomers { get; internal set; }
    }
}