using Apricot.Shared.Model;
using Apricot.Shared.Model.Service;
using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     ViewModel for Main view.
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
            // Initialize members.
            _navigationService = navigationService;
            _serverService = new ServerService();

            // Initialize properties.
            Model = new MainModel();
            _InitializeCommands();
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
        ///     Initialize commands.
        /// </summary>
        private void _InitializeCommands()
        {
            Model.OnLoadedCommand = new RelayCommand(_OnLoaded);
            Model.RetryCommand = new RelayCommand(_TestServerConnection);
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            _TestServerConnection();
        }

        /// <summary>
        ///     Test the server connection.
        /// </summary>
        private async void _TestServerConnection()
        {
            Model.RetryIsVisible = false;
            Model.IsLoading = true;

            try
            {
                // Obtains the health of server
                // and checks if the server is up.
                var health = await _serverService.GetHealth();

                // If the server is up, it navigate to a next view,
                // otherwise, it show a error message.
                Model.RetryIsVisible = health.Status == ServerHealthModel.HealthStatus.Down;
                if (health.Status == ServerHealthModel.HealthStatus.Up)
                {
                    _GoToPlantChooserView();
                }
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