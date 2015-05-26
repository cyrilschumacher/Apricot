using Apricot.Shared.Models;
using Apricot.Shared.Models.Service;
using Apricot.Shared.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModels
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
            MessengerInstance.Register<PlantServiceModel>(this, _OnPlantChooserMessage);

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
        ///     Plant.
        /// </summary>
        private PlantServiceModel _plant;

        #endregion Members.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            // Register messengers.
            MessengerInstance.Register<PlantServiceModel>(this, _OnPlantChooserMessage);
        }

        /// <summary>
        ///     Receives the plant.
        /// </summary>
        /// <param name="plant">The plant information.</param>
        private void _OnPlantChooserMessage(PlantServiceModel plant)
        {
            _plant = plant;
        }

        #endregion Events.

        /// <summary>
        ///     Pins the plant as a favorite plant.
        /// </summary>
        private void _Pin()
        {
            _plantFavoriteService.Add(_plant.Id);
        }

        /// <summary>
        ///     Returns a value indicating whether the command to pins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _PinCanExecute()
        {
            return true;
            //return _plantFavoriteService.Exists(_plant.Id);
        }

        /// <summary>
        ///     Unpins the plant.
        /// </summary>
        private void _Unpin()
        {
            _plantFavoriteService.Remove(_plant.Id);
        }

        /// <summary>
        ///     Returns a value indicating whether the command to unpins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _UnpinCanExecute()
        {
            return true;
            //return !_plantFavoriteService.Exists(_plant.Id);
        }

        #endregion Methods.
    }
}