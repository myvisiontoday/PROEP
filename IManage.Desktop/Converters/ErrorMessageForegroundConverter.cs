using MvvmCross.Platform.Converters;
using System;
using System.Globalization;
using System.Windows.Media;

namespace IManage.Converters
{
    /// <summary>
    /// A class which converts string message to color
    /// </summary>
    public class ErrorMessageForegroundConverter : MvxValueConverter<string, SolidColorBrush>
    {
        #region Base class Overrides
        protected override SolidColorBrush Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Colors.Red);
        }
        #endregion
    }
}
