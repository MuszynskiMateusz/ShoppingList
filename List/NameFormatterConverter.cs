using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace List
{
    public class NameFormatterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                // Dodanie spacji między cyframi i literami
                return System.Text.RegularExpressions.Regex.Replace(name, @"(\D)(\d)", "$1 $2");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}