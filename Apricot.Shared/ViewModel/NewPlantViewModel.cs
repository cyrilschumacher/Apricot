using Apricot.Shared.Model;
using GalaSoft.MvvmLight;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     View model for the "new plant" view.
    /// </summary>
    public class NewPlantViewModel : ViewModelBase
    {
        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public NewPlantModel Model { get; private set; }

        #endregion Properties.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public NewPlantViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                Model = new NewPlantModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    OnUnloadedCommand = new RelayCommand(_OnUnloaded)
                };
            }
        }

        #endregion Constructor.

        #region Methods.

        /// <summary>
        ///     Occurs when the user presses the hardware Back button.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
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
            HardwareButtons.BackPressed += HardwareButtonsOnBackPressed;
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            HardwareButtons.BackPressed -= HardwareButtonsOnBackPressed;
        }

        #endregion Methods.
    }
}