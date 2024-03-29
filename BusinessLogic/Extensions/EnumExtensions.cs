using System.ComponentModel;
using BusinessLogic.Enums;

namespace BusinessLogic.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this StorageBucket val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes is { Length: > 0 } ? attributes[0].Description : string.Empty;
        }

        public static string ToDescription(this Template val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes is { Length: > 0 } ? attributes[0].Description : string.Empty;
        }
    }
}