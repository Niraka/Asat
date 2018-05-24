using Asat.Framework;
using Asat.Framework.Event;
using Asat.Tools;

namespace Asat.Modules.Validation
{
    public class ValidationModule : Framework.Module
    {
        public ValidationModule(ModuleConfig config) : base(config)
        {
        }

        public int Test(DatabaseAddress address)
        {
            return 5;
        }
    }
}
