using System.Windows.Input;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for main view.
    /// </summary>
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
        /// <value>Tthe value that indicates a loading.</value>
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetValueProperty(ref _isLoading, value);
            }
        }

        /// <summary>
        ///     Get or sets a command for OnLoaded event.
        /// </summary>
        /// <value>The command for OnLoaded event</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Get or sets a command for retry connection to server.
        /// </summary>
        /// <value>The command for retry connection to server</value>
        public ICommand RetryCommand { get; set; }

        /// <summary>
        ///     Gets or sets a visibility of the retry action.
        /// </summary>
        /// <value>The visibility of the retry action</value>
        public bool RetryIsVisible
        {
            get
            {
                return _retryIsVisible;
            }
            set
            {
                SetValueProperty(ref _retryIsVisible, value);
            }
        }

        #endregion Properties.
    }
}