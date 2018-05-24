using System;

namespace Asat.Framework
{
    public class ApiContextException : Exception
    {
        public ApiContextException()
        {
        }

        public ApiContextException(string sMessage) : base(sMessage)
        {
        }

        public ApiContextException(string sMessage, Exception innerException) : 
            base(sMessage, innerException)
        {
        }
    }
}
