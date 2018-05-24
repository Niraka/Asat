namespace Asat.Framework
{
    public class EngineConfig
    {
        private string m_sApplicationName;

        public EngineConfig()
        {
            m_sApplicationName = string.Empty;
        }

        public EngineConfig(string sApplicationName)
        {
            m_sApplicationName = sApplicationName;
        }

        public string GetApplicationName()
        {
            return m_sApplicationName;
        }
    }
}
