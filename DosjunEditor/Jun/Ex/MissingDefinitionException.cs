using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun.Ex
{
    public class MissingDefinitionException : JunException
    {
        public MissingDefinitionException()
        {
        }

        public MissingDefinitionException(string message) : base(message)
        {
        }

        public MissingDefinitionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingDefinitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
