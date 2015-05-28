using Apricot.Shared.Extensions;
using Apricot.Shared.Models;
using Apricot.Shared.Models.Messages;
using Apricot.Shared.Models.Services;
using Apricot.Shared.Models.ViewModels;
using Apricot.Shared.Services;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for the "plant information" view.
    /// </summary>
    [CLSCompliant(false)]
    public class PlantViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        /// </summary>
        private const long LatestMeasureDuration = 5;

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     Service for manage alert.
        /// </summary>
        private readonly AlertService _alertService;

        /// <summary>
        ///     Service for manage measure.
        /// </summary>
        private readonly MeasureService _measureService;

        /// <summary>
        ///     Navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        ///     Service for manage plant favorite.
        /// </summary>
        private readonly PlantFavoriteService _plantFavoriteService;

        /// <summary>
        ///     Service for manage plant.
        /// </summary>
        private readonly PlantService _plantService;

        /// <summary>
        ///     Real time measure.
        /// </summary>
        private readonly DispatcherTimer _realTimeMeasureTimer;

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
        /// <param name="navigationService">A navigation service.</param>
        public PlantViewModel(INavigationService navigationService)
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _alertService = new AlertService();
                _measureService = new MeasureService();
                _navigationService = navigationService;
                _plantService = new PlantService();
                _plantFavoriteService = new PlantFavoriteService();
                _realTimeMeasureTimer = new DispatcherTimer
                {
                    Interval = new TimeSpan(LatestMeasureDuration * TimeSpan.TicksPerSecond)
                };

                // Initialize properties.
                Model = new PlantModel
                {
                    GoToChartPageCommand = new RelayCommand<string>(_GoToMeasureChart),
                    GoToVarietyInformationPageCommand = new RelayCommand(_GoToVarietyInformationPage),
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    OnUnloadedCommand = new RelayCommand(_OnUnloaded),
                    PinCommand = new RelayCommand(_Pin, _PinCanExecute),
                    StopCommand = new RelayCommand(_StopMeasuresAsync, _StopMeasureCanExecute),
                    UnpinCommand = new RelayCommand(_Unpin, _UnpinCanExecute)
                };

                // Register messengers.
                MessengerInstance.Register<PlantServiceModel>(this, _OnPlantChooserMessage);
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
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            if (Model.Details != null)
            {
                // If details on the plant exists,
                // it clears and obtains new details of the web service.
                _ResetDetails();
                _LoadDetailsAsync();
            }

            // Initializes events.
            _realTimeMeasureTimer.Tick += _RefreshMeasure;
            HardwareButtons.BackPressed += _OnHardwareButtonsOnBackPressed;

            // Reloads the latest measure by a duration.
            _realTimeMeasureTimer.Start();
        }

        /// <summary>
        ///     Receives the plant.
        /// </summary>
        /// <param name="plant">The plant information.</param>
        private void _OnPlantChooserMessage(PlantServiceModel plant)
        {
            // Sets the plant information.
            Model.Identifier = plant.Identifier;
            Model.IsActive = plant.IsActive;
            Model.Name = plant.Name;

            // Loads the details of plant, the latest measure and the measures.
            _LoadDetailsAsync();
            _LoadLatestMeasureAsync();
            _LoadAlertAsync();
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            // Removes events.
            _realTimeMeasureTimer.Tick -= _RefreshMeasure;
            HardwareButtons.BackPressed -= _OnHardwareButtonsOnBackPressed;

            // Stops the timer.
            _realTimeMeasureTimer.Stop();
        }

        /// <summary>
        ///     Refreshs measures.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="o">The parameters.</param>
        private void _RefreshMeasure(object sender, object o)
        {
            if (Model.Details != null)
            {
                _LoadLatestMeasureAsync();
                _LoadAlertAsync();
            }
        }

        #endregion Events.

        /// <summary>
        ///     Adds a photo.
        /// </summary>
        private async void _AddPhoto(string photo)
        {
            var bitmap = await BitmapImageExtensions.FromBase64(photo);
            Model.Details.Photos.Add(bitmap);
        }

        /// <summary>
        ///     Loads the defails of the plant.
        /// </summary>
        private async void _LoadDetailsAsync()
        {
            var details = await _plantService.GetDetailsPlantAsync(Model.Identifier);
            Model.Details = new PlantDetailsModel {Variety = details.Variety};

            if (details.Photos != null)
            {
                foreach (var photo in details.Photos)
                {
                    _AddPhoto(photo);
                }
            }
        }

        /// <summary>
        ///     Loads the 
        /// </summary>
        private async void _LoadAlertAsync()
        {
            Model.IsLoading = true;

            try
            {
                Model.RemainingTime = await _alertService.GetTimeRemainingAsync(Model.Identifier);
                Model.Alert = await _alertService.GetAlertAsync(Model.Identifier);
            }
            catch (Exception)
            {
                //todo: Manage errors.
            }
            finally
            {
                Model.IsLoading = false;
            }
        }

        /// <summary>
        ///     Loads the latest measure.
        /// </summary>
        private async void _LoadLatestMeasureAsync()
        {
            Model.LatestMeasure = await _measureService.GetLast(Model.Identifier);
        }

        /// <summary>
        ///     Pins the plant as a favorite plant.
        /// </summary>
        private void _Pin()
        {
            _plantFavoriteService.Add(Model.Identifier);

            // Refreshs commands.
            Model.PinCommand.RaiseCanExecuteChanged();
            Model.UnpinCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///     Returns a value indicating whether the command to pins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _PinCanExecute()
        {
            return !_plantFavoriteService.Exists(Model.Identifier);
        }

        /// <summary>
        ///     Goes to a page shows measure chart page.
        /// </summary>
        /// <param name="measureName">The name of measure.</param>
        private void _GoToMeasureChart(string measureName)
        {
            _navigationService.NavigateTo("MeasureChart");
            MessengerInstance.Send(new MeasureMessageModel { Name = measureName, PlantIdentifier = Model.Identifier });
        }

        /// <summary>
        ///     Goes to a page shows variety information page.
        /// </summary>
        private void _GoToVarietyInformationPage()
        {
            _navigationService.NavigateTo("VarietyDetails");
            MessengerInstance.Send(Model.Details.Variety);
        }

        /// <summary>
        ///     Resets plant details.
        /// </summary>
        private void _ResetDetails()
        {
            Model.Details = new PlantDetailsModel();
        }

        /// <summary>
        ///     Stop the measures of the plant.
        /// </summary>
        private async void _StopMeasuresAsync()
        {
            await _plantService.StopPlantAsync(Model.Identifier);

            Model.IsActive = false;
            Model.StopCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///     Returns a value indicating whether the command to stop measures is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _StopMeasureCanExecute()
        {
            return Model.IsActive;
        }

        /// <summary>
        ///     Unpins the plant.
        /// </summary>
        private void _Unpin()
        {
            _plantFavoriteService.Remove(Model.Identifier);

            // Refreshs commands.
            Model.PinCommand.RaiseCanExecuteChanged();
            Model.UnpinCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///     Returns a value indicating whether the command to unpins a plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _UnpinCanExecute()
        {
            return _plantFavoriteService.Exists(Model.Identifier);
        }

        #endregion Methods.
    }
}