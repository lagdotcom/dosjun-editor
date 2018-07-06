using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class MissingResourceException : JunException
    {
        public MissingResourceException()
        {
        }

        public MissingResourceException(string message) : base(message)
        {
        }

        public MissingResourceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
