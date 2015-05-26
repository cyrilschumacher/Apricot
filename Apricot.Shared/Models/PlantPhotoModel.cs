using System;
using Windows.UI.Xaml.Media.Imaging;

namespace Apricot.Shared.Models
{
    /// <summary>
    ///     Model for photo of plant.
    /// </summary>
    [CLSCompliant(false)]
    public class PlantPhotoModel
    {
        /// <summary>
        ///     Gets or sets a Base64 data.
        /// </summary>
        /// <value>The Base64 data.</value>
        public string Base64Data { get; set; }

        /// <summary>
        ///     Gets or sets a image.
        /// </summary>
        /// <value>The image.</value>
        public BitmapImage Image { get; set; }
    }
}