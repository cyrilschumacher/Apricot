using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
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

        /// <summary>
        /// 
        /// </summary>
        private bool _retryIsVisible;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Command for OnLoaded event.
        /// </summary>
        public ICommand OnLoadedCommand { get; private set; }

        /// <summary>
        ///     Command for retry connection to server.
        /// </summary>
        public ICommand RetryCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RetryIsVisible
        {
            get { return _retryIsVisible; }
            private set
            {
                _retryIsVisible = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MainViewModel()
        {
            _serverService = new ServerService();
            _InitializeCommands();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Initialize commands.
        /// </summary>
        private void _InitializeCommands()
        {
            OnLoadedCommand = new RelayCommand(_OnLoaded);
            RetryCommand = new RelayCommand(_TestServerConnection);
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
                RetryIsVisible = false;
                var health = await _serverService.GetHealth();
                if (health.Status == ServerHealthModel.HealthStatus.Down)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                RetryIsVisible = true;
            }
        }

        #endregion Methods.
    }
}