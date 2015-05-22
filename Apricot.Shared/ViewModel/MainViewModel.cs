using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using Apricot.Shared.Model;
using Apricot.Shared.Model.Service;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     ViewModel for Main view.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Members.

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
        public MainViewModel()
        {
            // Initialize members.
            _serverService = new ServerService();

            // Initialize properties.
            Model = new MainModel();
            _InitializeCommands();
        }

        #endregion Constructors.

        #region Methods.

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
            try
            {
                Model.RetryIsVisible = false;
                var health = await _serverService.GetHealth();
                if (health.Status == ServerHealthModel.HealthStatus.Down)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Model.RetryIsVisible = true;
            }
        }

        #endregion Methods.
    }
}