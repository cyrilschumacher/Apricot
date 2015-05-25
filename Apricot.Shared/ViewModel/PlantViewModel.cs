using Apricot.Shared.Model;
using Apricot.Shared.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     View model for the "plant information" view.
    /// </summary>
    public class PlantViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Service for manage plant favorite.
        /// </summary>
        private readonly PlantFavoriteService _plantFavoriteService;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        public PlantModel Model { get; private set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize properties.
                Model = new PlantModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    PinCommand = new RelayCommand(_Pin),
                    UnpinCommand = new RelayCommand(_Unpin)
                };
            }
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {

        }

        /// <summary>
        ///     Pin the plant as a favorite plant.
        /// </summary>
        private void _Pin()
        {
        }

        /// <summary>
        ///     Unpin the plant.
        /// </summary>
        private void _Unpin()
        {
        }

        #endregion Methods.
    }
}
