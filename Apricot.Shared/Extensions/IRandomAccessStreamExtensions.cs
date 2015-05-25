using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Apricot.Shared.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="IRandomAccessStream" />.
    /// </summary>
    [CLSCompliant(false)]
    public static class IRandomAccessStreamExtensions
    {
        #region Methods.

        /// <summary>
        ///     Convert <see cref="IRandomAccessStream" /> to Base64 data .
        /// </summary>
        /// <param name="stream">Data stream.</param>
        /// <returns>The base64 data.</returns>
        public static async Task<string> ToBase64(this IRandomAccessStream stream)
        {
            var buffer = new byte[stream.Size];
            await stream.ReadAsync(buffer.AsBuffer(), (uint) stream.Size, InputStreamOptions.None);
                
            return Convert.ToBase64String(buffer);
        }

        #endregion Methods.
    }
}