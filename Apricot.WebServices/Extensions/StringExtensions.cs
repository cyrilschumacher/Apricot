using System;
using Windows.Data.Json;

namespace Apricot.WebServices.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        #region Methods.

        /// <summary>
        ///     Indicates whether the specified string is JSON data valid.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>True if the string is JSON data valid, otherwise, False.</returns>
        public static bool IsValidJson(this string value)
        {
            JsonValue result;
            return JsonValue.TryParse(value, out result);
        }

        /// <summary>
        ///     Indicates whether the specified string is Base64 data valid. 
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>True if the string is Base64 data valid, otherwise, False.</returns>
        public static bool IsValidBase64(this string value)
        {
            try
            {
                Convert.FromBase64String(value);
                return (value.Replace(" ", string.Empty).Length % 4 == 0);
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods.
    }
}