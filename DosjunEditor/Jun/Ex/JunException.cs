using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public abstract class JunException : Exception
    {
        public JunException()
        {
        }

        public JunException(string message) : base(message)
        {
        }

        public JunException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JunException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
