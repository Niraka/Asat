using Asat.Framework;
using Asat.Framework.Event;

namespace Asat.Modules.Settings
{
    public class SettingsModule : Asat.Framework.Module
    {
        private Database.DatabaseModule m_databaseModule;

        public SettingsModule(ModuleConfig config) : base(config)
        {
            m_databaseModule = null;
        }

        public override void OnDependencyAvailable(Module module)
        {
            if (module.GetName() == "database")
            {
                m_databaseModule = (Database.DatabaseModule)module;
            }
        }

        public override void OnDependencyUnavailable(Module module)
        {
            if (module.GetName() == "database")
            {
                m_databaseModule = null;
            }
        }
    }
}
