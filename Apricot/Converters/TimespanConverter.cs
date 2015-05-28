using System;
using Windows.UI.Xaml.Data;

namespace Apricot.Converters
{
    //todo: Add documentation.
    //todo: To fix
    public class TimespanConverter : IValueConverter
    {
        /// <summary>
        ///     Default format of <see cref="TimeSpan" />.
        /// </summary>
        private const string DefaultFormat = @"d\:hh\:mm";

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
            int timeStamp;
            if (!int.TryParse(value.ToString(), out timeStamp))
            {
                return value;
            }

            var parameterString = parameter as string;
            var format = parameterString ?? DefaultFormat;

            return new TimeSpan(0, 0, timeStamp).ToString(format);
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