using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class OverflowException : JunException
    {
        public OverflowException()
        {
        }

        public OverflowException(string message) : base(message)
        {
        }

        public OverflowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OverflowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
