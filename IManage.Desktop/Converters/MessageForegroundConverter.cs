using IManage.Core.Models;
using MvvmCross.Platform.Converters;
using System;
using System.Globalization;
using System.Windows.Media;

namespace IManage.Converters
{
    /// <summary>
    /// A class which converts enum message to color
    /// </summary>
    public class MessageForegroundConverter : MvxValueConverter<Message, SolidColorBrush>
    {
        #region Base class overrides
        protected override SolidColorBrush Convert(Message value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            Message message = value;

            if ((message == Message.NotAllFieldsComplete) ||
                (message == Message.UnSaved) ||
                (message == Message.UpdateUnsucess) ||
                (message == Message.DeleteUnsucess))
                return new SolidColorBrush(Colors.Red);

            if ((message == Message.Saved) ||
                (message == Message.Deleted) ||
                (message == Message.Updated))
            {
                return new SolidColorBrush(Colors.Green);
            }

            return null;
        }
        #endregion
    }
}
