using Apricot.Shared.Models.ViewModels;
using Apricot.WebServices.Models.Server;
using Apricot.WebServices.Server;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for verify server availability.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        ///     Server service.
        /// </summary>
        private readonly ServerService _serverService;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Get or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for OnLoaded event</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Get or sets a command for retry connection to server.
        /// </summary>
        /// <value>The command for retry connection to server</value>
        public ICommand RetryCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public MainModel Model { get; private set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="navigationService">A navigation service.</param>
        public MainViewModel(INavigationService navigationService)
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _navigationService = navigationService;
                _serverService = new ServerService();

                // Initialize properties.
                Model = new MainModel();
                OnLoadedCommand = new RelayCommand(_OnLoadedAsync);
                RetryCommand = new RelayCommand(_TestServerConnectionAsync);
            }
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Go to a Plant Chooser view.
        /// </summary>
        private void _GoToPlantChooserView()
        {
            _navigationService.NavigateTo("PlantChooser");
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private async void _OnLoadedAsync()
        {
            // Wait 2 seconds to avoid a graphical artifact (black screen with spinner).
            await Task.Delay(2000);
            _TestServerConnectionAsync();
        }

        /// <summary>
        ///     Test the server connection.
        /// </summary>
        private async void _TestServerConnectionAsync()
        {
            Model.RetryIsVisible = false;
            Model.IsLoading = true;

            try
            {
                // Obtains the health of server
                // and checks if the server is up.
                var health = await _serverService.GetHealthAsync();

                // If the server is up, it navigate to a next view,
                // otherwise, it show a error message.
                Model.RetryIsVisible = health.Status != ServerHealthModel.HealthStatus.Up;
                if (health.Status == ServerHealthModel.HealthStatus.Down)
                {
                    throw new Exception("The server is down.");
                }

                _GoToPlantChooserView();
            }
            catch (Exception)
            {
                Model.RetryIsVisible = true;
            }
            finally
            {
                Model.IsLoading = false;
            }
        }

        #endregion Methods.
    }
}