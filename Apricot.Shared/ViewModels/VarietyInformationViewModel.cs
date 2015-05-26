using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows information of variety of a plant.
    /// </summary>
    public class VarietyInformationViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Variety plant service.
        /// </summary>
        private VarietyPlantService _varietyPlantService;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public VarietyInformationViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _varietyPlantService = new VarietyPlantService();
            }
        }

        #endregion Constructors.
    }
}
