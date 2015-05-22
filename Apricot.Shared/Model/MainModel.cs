using System.Windows.Input;

namespace Apricot.Shared.Model
{
    public class MainModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///    Value that indicates a loading.
        /// </summary>
        private bool _isLoading;

        /// <summary>
        ///    Visibility of the retry action.
        /// </summary>
        private bool _retryIsVisible;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a value that indicates a loading.
        /// </summary>
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetValueProperty(ref _isLoading, value); }
        } 

        /// <summary>
        ///     Command for OnLoaded event.
        /// </summary>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Command for retry connection to server.
        /// </summary>
        public ICommand RetryCommand { get; set; }

        /// <summary>
        ///     Gets the visibility of the retry action.
        /// </summary>
        public bool RetryIsVisible
        {
            get { return _retryIsVisible; }
            set { SetValueProperty(ref _retryIsVisible, value); }
        } 

        #endregion Properties.
    }
}
