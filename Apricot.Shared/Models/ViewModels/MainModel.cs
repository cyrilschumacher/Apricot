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