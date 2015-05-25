using System;
using System.IO;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Apricot.Shared.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="BitmapImage"/>.
    /// </summary>
    public static class BitmapImageExtensions
    {
        #region Methods.

        /// <summary>
        ///     Convert Base64 data to <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="base64String">Base64 data.</param>
        /// <returns>A bitmap image.</returns>
        public async static Task<BitmapImage> FromBase64(string base64String)
        {
            var rawData = Convert.FromBase64String(base64String);
            using (var memory = new MemoryStream(rawData, 0, rawData.Length))
            {
                var bitmap = new BitmapImage();

                await bitmap.SetSourceAsync(memory.AsRandomAccessStream());
                return bitmap;
            }
        }

        #endregion Methods.
    }
}