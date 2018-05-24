namespace Asat.Tools
{
    public class Maths
    {
        public static long Clamp(long iValue, long iLower, long iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static ulong Clamp(ulong iValue, ulong iLower, ulong iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static int Clamp(int iValue, int iLower, int iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static uint Clamp(uint iValue, uint iLower, uint iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static short Clamp(short iValue, short iLower, short iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static ushort Clamp(ushort iValue, ushort iLower, ushort iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static byte Clamp(byte iValue, byte iLower, byte iUpper)
        {
            return iValue >= iUpper ? iUpper : iValue <= iLower ? iLower : iValue;
        }
        public static double Clamp(double fValue, double fLower, double fUpper)
        {
            return fValue >= fUpper ? fUpper : fValue <= fLower ? fLower : fValue;
        }
        public static float Clamp(float fValue, float fLower, float fUpper)
        {
            return fValue >= fUpper ? fUpper : fValue <= fLower ? fLower : fValue;
        }
    }
}
