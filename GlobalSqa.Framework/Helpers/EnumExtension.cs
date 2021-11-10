using System;

namespace GlobalSqa.Framework.Helpers
{
    public static class EnumExtension
    {
        public static string GetStringValue(this Enum value)
        {
            string output = null;
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attributes != null && attributes.Length > 0)
            {
                output = attributes[0].Value;
            }

            return output;
        }
    }
}
