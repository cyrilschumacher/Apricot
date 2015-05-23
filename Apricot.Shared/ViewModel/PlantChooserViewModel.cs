using Apricot.Shared.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     ViewModel for Plant chooser view.
    /// </summary>
    public class PlantChooserViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public PlantChooserModel Model { get; private set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="navigationService">A navigation service.</param>
        public PlantChooserViewModel(INavigationService navigationService)
        {
            // Initialize members.
            _navigationService = navigationService;

            // Initialize properties.
            Model = new PlantChooserModel();
        }

        #endregion Constructors.
    }
}
