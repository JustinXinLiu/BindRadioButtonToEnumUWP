using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BindRadioButtonToEnumUWP
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var enumName = Enum.GetName(value.GetType(), value);
            var attribute = value.GetType().GetTypeInfo().GetDeclaredField(enumName).
                GetCustomAttribute<DisplayAttribute>();

            return attribute != null ? attribute.Name : enumName;
        }

        public static IEnumerable<TEnum> GetValues<TEnum>(this Type enumType) where TEnum : struct, IConvertible
        {
            if (!enumType.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an Enum!");
            }

            return Enum.GetValues(enumType).Cast<TEnum>();
        }
    }
}