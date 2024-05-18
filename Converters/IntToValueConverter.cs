using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AnimeList.Converters
{
    public class IntToVisibility : IntToValueConverter<Visibility> { }
    public class IntToValueConverter<T> : IValueConverter
    {
        public int Int { get; set; }
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? FalseValue : ((int)value == Int ? TrueValue : FalseValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
