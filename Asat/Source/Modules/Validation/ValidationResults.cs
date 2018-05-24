namespace Asat.Modules.Validation
{
    public class ValidationResults<DataType>
    {
        private bool m_bIsValid;
        private bool m_bHasCorrection;
        private DataType m_data;
        private string m_sFailureReason;

        public ValidationResults()
        {
            m_bIsValid = false;
            m_bHasCorrection = false;
            m_data = default(DataType);
            m_sFailureReason = string.Empty;
        }

        public ValidationResults(bool bIsValid)
        {
            m_bIsValid = bIsValid;
            m_bHasCorrection = false;
            m_data = default(DataType);
            m_sFailureReason = string.Empty;
        }

        public ValidationResults(bool bIsValid, bool bHasCorrection, DataType data, string sFailureReason)
        {
            m_bIsValid = bIsValid;
            m_bHasCorrection = bHasCorrection;
            m_data = data;
            m_sFailureReason = sFailureReason;
        }

        public bool IsValid()
        {
            return m_bIsValid;
        }

        public bool HasCorrection()
        {
            return m_bHasCorrection;
        }

        public DataType GetCorrection()
        {
            return m_data;
        }

        public string GetFailureReason()
        {
            return m_sFailureReason;
        }
    }
}
