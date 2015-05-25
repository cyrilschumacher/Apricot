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
                // Initialize members.
                _plantFavoriteService = new PlantFavoriteService();

                // Initialize properties.
                Model = new PlantModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    PinCommand = new RelayCommand(_Pin, _PinCanExecute),
                    UnpinCommand = new RelayCommand(_Unpin, _UnpinCanExecute)
                };
            }
        }

        #endregion Constructors.

        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public PlantModel Model { get; private set; }

        #endregion Properties.

        #region Members.

        /// <summary>
        ///     Service for manage plant favorite.
        /// </summary>
        private readonly PlantFavoriteService _plantFavoriteService;

        /// <summary>
        ///     Plant identifier.
        /// </summary>
        private string _plantId;

        #endregion Members.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            // Register messengers.
            MessengerInstance.Register<string>(this, _OnPlantChooserMessage);
        }

        /// <summary>
        ///     Receives the plant identifier.
        /// </summary>
        /// <param name="plantId"></param>
        private void _OnPlantChooserMessage(string plantId)
        {
            _plantId = plantId;
        }

        #endregion Events.

        /// <summary>
        ///     Pins the plant as a favorite plant.
        /// </summary>
        private void _Pin()
        {
            _plantFavoriteService.Add(_plantId);
        }

        /// <summary>
        ///     Returns a value indicating whether the command to pins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _PinCanExecute()
        {
            return _plantFavoriteService.Exists(_plantId);
        }

        /// <summary>
        ///     Unpins the plant.
        /// </summary>
        private void _Unpin()
        {
            _plantFavoriteService.Remove(_plantId);
        }

        /// <summary>
        ///     Returns a value indicating whether the command to unpins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _UnpinCanExecute()
        {
            return !_plantFavoriteService.Exists(_plantId);
        }

        #endregion Methods.
    }
}