namespace Asat.Modules.Validation
{
    public class Strings
    {
        public static ValidationResults<string> IsNumeric(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }

            for (int i = 0; i < sValue.Length; ++i)
            {
                if (sValue[i] < '0' || sValue[i] > '9')
                {
                    return new ValidationResults<string>(false, false, null, "non-numeric character");
                }
            }

            return new ValidationResults<string>(true);
        }

        public static ValidationResults<string> IsAlphabetical(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }

            for (int i = 0; i < sValue.Length; ++i)
            {
                if (sValue[i] >= 'a' && sValue[i] <= 'z')
                {
                    continue;
                }

                if (sValue[i] >= 'A' && sValue[i] <= 'Z')
                {
                    continue;
                }

                return new ValidationResults<string>(false, false, null, "non-alphabetical character");
            }

            return new ValidationResults<string>(true);
        }

        public static ValidationResults<string> IsAlphanumeric(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }

            for (int i = 0; i < sValue.Length; ++i)
            {
                if (sValue[i] >= '0' && sValue[i] <= '9')
                {
                    continue;
                }

                if (sValue[i] >= 'a' && sValue[i] <= 'z')
                {
                    continue;
                }

                if (sValue[i] >= 'A' && sValue[i] <= 'Z')
                {
                    continue;
                }

                return new ValidationResults<string>(false, false, null, "non-alphanumeric character");
            }

            return new ValidationResults<string>(true);
        }

        public static ValidationResults<string> IsBoolean(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }
            
            if (sValue.ToLower() == "true" || sValue.ToLower() == "t" || sValue == "1")
            {
                return new ValidationResults<string>(true);
            }
            else if (sValue.ToLower() == "false" || sValue.ToLower() == "f" || sValue == "0")
            {
                return new ValidationResults<string>(true);
            }

            return new ValidationResults<string>(false, false, null, "invalid value");
        }

        public static ValidationResults<string> IsInteger(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }

            if (sValue.Length == 1)
            {
                if (sValue[0] < '0' || sValue[0] > '9')
                {
                    return new ValidationResults<string>(false, false, null, "first character must be a number or sign");
                }
                else
                {
                    return new ValidationResults<string>(true);
                }
            }
            else
            {
                if (sValue[0] != '-' && sValue[0] != '+' && (sValue[0] < '0' || sValue[0] > '9'))
                {
                    return new ValidationResults<string>(false, false, null, "first character must be a number or sign");
                }
            }

            for (int i = 1; i < sValue.Length; ++i)
            {
                if (sValue[i] < '0' || sValue[i] > '9')
                {
                    return new ValidationResults<string>(false, false, null, "non-numeric character");
                }
            }

            return new ValidationResults<string>(true);
        }

        public static ValidationResults<string> IsFloat(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return new ValidationResults<string>(false, false, null, "empty string");
            }

            bool bFoundPoint = false;
            if (sValue.Length == 1)
            {
                if (sValue[0] < '0' || sValue[0] > '9')
                {
                    return new ValidationResults<string>(false, false, null, "first character must be a number or sign");
                }
                else
                {
                    return new ValidationResults<string>(true);
                }
            }
            else
            {
                if (sValue[0] == '.')
                {
                    bFoundPoint = true;
                }
                else if (sValue[0] != '-' && sValue[0] != '+' && (sValue[0] < '0' || sValue[0] > '9'))
                {
                    return new ValidationResults<string>(false, false, null, "first character must be a number or sign");
                }
            }

            for (int i = 1; i < sValue.Length - 1; ++i)
            {
                if (sValue[i] == '.')
                {
                    if (bFoundPoint)
                    {
                        return new ValidationResults<string>(false, false, null, "too many points");
                    }
                    else
                    {
                        bFoundPoint = true;
                        continue;
                    }
                }

                if (sValue[i] < '0' || sValue[i] > '9')
                {
                    return new ValidationResults<string>(false, false, null, "non-numeric character");
                }
            }

            if (sValue[sValue.Length - 1] == '.')
            {
                if (bFoundPoint)
                {
                    return new ValidationResults<string>(false, false, null, "too many points");
                }
                else
                {
                    return new ValidationResults<string>(true, true, sValue.Substring(0, sValue.Length - 1), string.Empty);
                }
            }
            else if (sValue[sValue.Length - 1] < '0' || sValue[sValue.Length - 1] > '9')
            {
                return new ValidationResults<string>(false, false, null, "last character must be a number");
            }

            return new ValidationResults<string>(true);
        }
    }
}
