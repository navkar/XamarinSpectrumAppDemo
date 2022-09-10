using System;
using System.Globalization;
using Xamarin.Forms;

namespace SpectrumApp.Converters
{
    public class DatetimeToStringConverter : IValueConverter
    {
        public DatetimeToStringConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("yyyy");
        }
    }
}

