namespace Dwellers.Common.Application
{
    public class EnumConverter
    {
        public static int ConvertEnumToInt<TEnum>(TEnum enumValue) where TEnum : struct, Enum
        {
            return Convert.ToInt32(enumValue);
        }
    }
}
