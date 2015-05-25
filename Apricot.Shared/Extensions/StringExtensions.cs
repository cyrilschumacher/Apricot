using Windows.Data.Json;

namespace Apricot.Shared.Extension
{
    /// <summary>
    ///     Extension class for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Indicates whether the specified string is JSON data valid.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>True if the string is JSON data valid, otherwise, False.</returns>
        public static bool IsJsonValue(this string value)
        {
            JsonValue result;
            return JsonValue.TryParse(value, out result);
        }
    }
}
