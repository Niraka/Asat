using System;

namespace Asat.Framework
{
    public class ModuleException : Exception
    {
        public ModuleException()
        {
        }

        public ModuleException(string sMessage) : base(sMessage)
        {
        }

        public ModuleException(string sMessage, Exception innerException) : 
            base(sMessage, innerException)
        {
        }
    }
}
