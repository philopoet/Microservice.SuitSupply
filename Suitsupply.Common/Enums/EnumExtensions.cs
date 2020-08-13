using System.ComponentModel;

namespace Suitsupply.Common.Enums
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(this TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
