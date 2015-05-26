using System.IO;
using Windows.Data.Json;

namespace Apricot.Shared.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="string" />.
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

        /// <summary>
        ///     Converts a string value into a stream.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns>The stream.</returns>
        public static Stream ToStream(this string value)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(value);

            // Reset the buffer and the position.
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}