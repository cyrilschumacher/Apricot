using Apricot.Shared.Models.Messages;
using Apricot.Shared.Models.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows measure chart.
    /// </summary>
    public class MeasureChartViewModel : ViewModelBase
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public MeasureChartModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MeasureChartViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize properties.
                Model = new MeasureChartModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoaded)
                };

                // Register messengers.
                MessengerInstance.Register<MeasureMessageModel>(this, _OnMeasureServiceMessage);
            }
        }

        #endregion Constructors.

        #region Methods.

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
            // Initializes events.
            HardwareButtons.BackPressed += _OnHardwareButtonsOnBackPressed;
        }

        /// <summary>
        ///     Receives the measures (with its name).
        /// </summary>
        /// <param name="message">The message.</param>
        private void _OnMeasureServiceMessage(MeasureMessageModel message)
        {
            Model.Measures = message.Measures;
            Model.Name = message.Name;
        }

        #endregion Methods.
    }
}