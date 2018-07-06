using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class ArgumentCountException : JunException
    {
        public ArgumentCountException()
        {
        }

        public ArgumentCountException(string message) : base(message)
        {
        }

        public ArgumentCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
