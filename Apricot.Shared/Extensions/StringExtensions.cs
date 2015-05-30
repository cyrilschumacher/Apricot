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