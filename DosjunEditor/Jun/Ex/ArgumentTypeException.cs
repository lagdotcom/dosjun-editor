using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class ArgumentTypeException : JunException
    {
        public ArgumentTypeException()
        {
        }

        public ArgumentTypeException(string message) : base(message)
        {
        }

        public ArgumentTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
