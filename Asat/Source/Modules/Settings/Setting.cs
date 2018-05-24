namespace Asat.Modules.Settings
{
    /// <summary>
    /// A setting is an immutable pairing of a name and value that represents a configuration to 
    /// be applied to a system or process.
    /// </summary>
    /// <typeparam name="ValueType">The type of value the setting will hold</typeparam>
    public class Setting<ValueType>
    {
        private string m_sName;
        private ValueType m_value;
        private bool m_bIsDefault;

        /// <summary>
        /// Constructs a default configured setting.
        /// </summary>
        public Setting()
        {
            m_sName = string.Empty;
            m_value = default(ValueType);
            m_bIsDefault = true;
        }
        
        /// <summary>
        /// Constructs an immutable setting.
        /// </summary>
        /// <param name="sName">The name by which to refer to the setting</param>
        /// <param name="value">The value of the setting</param>
        /// <param name="bIsDefault">Whether the setting is a default or explicitly specified value 
        /// or not</param>
        public Setting(string sName, ValueType value, bool bIsDefault)
        {
            m_sName = sName;
            m_value = value;
            m_bIsDefault = bIsDefault;
        }

        /// <summary>
        /// Gets the settings' name.
        /// </summary>
        /// <returns>The name</returns>
        public string GetName()
        {
            return m_sName;
        }

        /// <summary>
        /// Gets the settings' value.
        /// </summary>
        /// <returns>The value</returns>
        public ValueType GetValue()
        {
            return m_value;
        }

        /// <summary>
        /// Queries whether the value specified by the setting is a default value or not.
        /// </summary>
        /// <returns>True if the value is a default, false if it was explicitly specified</returns>
        public bool IsDefaultValue()
        {
            return m_bIsDefault;
        }
    }
}
