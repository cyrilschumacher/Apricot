using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace Apricot.Shared.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PlantDetailsModel : NotifyPropertyChanged
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        public ObservableCollection<BitmapImage> Photos { get; set; }

        /// <summary>
        ///     Gets or sets the variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        public int Variety { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantDetailsModel()
        {
            Photos = new ObservableCollection<BitmapImage>();
        }

        #endregion Constructors.
    }
}
