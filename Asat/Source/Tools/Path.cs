namespace Asat.Tools
{
    public class Path
    {
        private string m_sPath;

        public Path()
        {
            m_sPath = string.Empty;
        }

        public Path(string sPath)
        {
            m_sPath = sPath == null ? string.Empty : sPath;
            m_sPath = m_sPath.Replace('\\', System.IO.Path.DirectorySeparatorChar);
            m_sPath = m_sPath.Replace('/', System.IO.Path.DirectorySeparatorChar);
        }

        public string Get()
        {
            return m_sPath;
        }

        public static implicit operator Path(string sPath)
        {
            return new Path(sPath);
        }
    }
}
