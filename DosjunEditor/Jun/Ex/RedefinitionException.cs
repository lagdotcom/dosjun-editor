using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class RedefinitionException : JunException
    {
        public RedefinitionException()
        {
        }

        public RedefinitionException(string message) : base(message)
        {
        }

        public RedefinitionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RedefinitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
