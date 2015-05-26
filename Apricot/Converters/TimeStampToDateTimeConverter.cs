using System;
using Windows.UI.Xaml.Data;

namespace Apricot.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeStampToDateTimeConverter : IValueConverter
    {
        /// <summary>
        ///     Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            long timeStamp;
            if (long.TryParse(value.ToString(), out timeStamp))
            {
                // Creates a date time by a UNIX time.
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return dateTime.AddSeconds(timeStamp).ToLocalTime();
            }

            return value;
        }

        /// <summary>
        ///     Modifies the target data before passing it to the source object. This method is called only in TwoWay bindings.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
