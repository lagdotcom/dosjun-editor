using System;
using System.Runtime.Serialization;

namespace DosjunEditor.Jun
{
    [Serializable]
    internal class CodeException : Exception
    {
        public CodeException()
        {
        }

        public CodeException(string message) : base(message)
        {
        }

        public CodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}