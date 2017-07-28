using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BindRadioButtonToEnumUWP
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string enumString)
            {
                if (!Enum.IsDefined(EnumType, value))
                {
                    return DependencyProperty.UnsetValue;
                }

                var enumValue = Enum.Parse(EnumType, enumString);
                return enumValue.Equals(value);
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (parameter is string enumString)
            {
                return Enum.Parse(EnumType, enumString);
            }

            return DependencyProperty.UnsetValue;
        }
    }
}