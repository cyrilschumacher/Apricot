using System.Linq;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Apricot.Shared.Extensions;
using Apricot.Shared.Models;
using Apricot.Shared.Models.Services;
using Apricot.Shared.Services;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModels
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

        /// <summary>
        ///     
        /// </summary>
        private readonly PlantService _plantService;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public PlantModel Model { get; private set; }

        #endregion Properties.

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
                _plantService = new PlantService();
                _plantFavoriteService = new PlantFavoriteService();

                // Initialize properties.
                Model = new PlantModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    PinCommand = new RelayCommand(_Pin, _PinCanExecute),
                    UnpinCommand = new RelayCommand(_Unpin, _UnpinCanExecute),
                    OnUnloadedCommand = new RelayCommand(_OnUnloaded)
                };
                Model.Details = new PlantDetailsModel();
            }
        }

        #endregion Constructors.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Occurs when the user presses the hardware Back button.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnHardwareButtonsOnBackPressed(object sender, BackPressedEventArgs e)
        {
            // Handles the back button for avoid a application suspension.
            e.Handled = true;

            // Navigates to the previous page if the root frame is obtained.
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                rootFrame.GoBack();
            }
        }

        /// <summary>
        ///     Loads the defails of the plant.
        /// </summary>
        private async void _LoadDetailsAsync()
        {
            var details = await _plantService.GetDetailsPlantAsync(Model.Plant.Identifier);
            foreach (var photo in details.Photos)
            {
                _AddPhoto(photo);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        private async void _AddPhoto(string photo)
        {
            var bitmap = await BitmapImageExtensions.FromBase64(photo);
            Model.Details.Photos.Add(bitmap);
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            // Register messengers.
            MessengerInstance.Register<PlantServiceModel>(this, _OnPlantChooserMessage);
            HardwareButtons.BackPressed += _OnHardwareButtonsOnBackPressed;
        }

        /// <summary>
        ///     Receives the plant.
        /// </summary>
        /// <param name="plant">The plant information.</param>
        private void _OnPlantChooserMessage(PlantServiceModel plant)
        {
            Model.Plant = plant;
            _LoadDetailsAsync();
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            HardwareButtons.BackPressed -= _OnHardwareButtonsOnBackPressed;
            MessengerInstance.Unregister<PlantServiceModel>(this, _OnPlantChooserMessage);
        }

        #endregion Events.

        /// <summary>
        ///     Pins the plant as a favorite plant.
        /// </summary>
        private void _Pin()
        {
            _plantFavoriteService.Add(Model.Plant.Identifier);

            Model.PinCommand.RaiseCanExecuteChanged();
            Model.UnpinCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///     Returns a value indicating whether the command to pins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _PinCanExecute()
        {
            return !_plantFavoriteService.Exists(Model.Plant.Identifier);
        }

        /// <summary>
        ///     Unpins the plant.
        /// </summary>
        private void _Unpin()
        {
            _plantFavoriteService.Remove(Model.Plant.Identifier);

            Model.PinCommand.RaiseCanExecuteChanged();
            Model.UnpinCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///     Returns a value indicating whether the command to unpins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _UnpinCanExecute()
        {
            return _plantFavoriteService.Exists(Model.Plant.Identifier);
        }

        #endregion Methods.
    }
}