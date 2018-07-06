using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class TokenizationException : JunException
    {
        public TokenizationException()
        {
        }

        public TokenizationException(string message) : base(message)
        {
        }

        public TokenizationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TokenizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
