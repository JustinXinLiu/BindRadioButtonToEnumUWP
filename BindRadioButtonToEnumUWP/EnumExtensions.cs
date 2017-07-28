using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public static IEnumerable<T> GetValues<T>() => 
            Enum.GetValues(typeof(T)).Cast<T>();
    }
}