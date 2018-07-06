using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class ScopeException : JunException
    {
        public ScopeException()
        {
        }

        public ScopeException(string message) : base(message)
        {
        }

        public ScopeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ScopeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
