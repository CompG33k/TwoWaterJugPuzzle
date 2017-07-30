using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace TwoWaterJugPuzzle.Converters
{
    public class StringFormatToIntConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var inttext =
                    Regex.Replace((string)value, "[^.0-9]", "");

                int number;
                return int.TryParse(inttext, out number) ? number : 0;
            }
            return value;
        }
        #endregion
    }
}
