using System.IO;

namespace Apricot.Shared.Extension
{
    /// <summary>
    ///     Extension class for <see cref="Stream" />.
    /// </summary
    public static class StreamExtensions
    {
        /// <summary>
        ///     Converts a stream into a byte array.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            using (var memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                return memory.ToArray();
            }
        }
    }
}