using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class TokenTypeException : JunException
    {
        public TokenTypeException()
        {
        }

        public TokenTypeException(string message) : base(message)
        {
        }

        public TokenTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TokenTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
