using System.Windows.Input;
using Apricot.Shared.Models.ViewModels;
using GalaSoft.MvvmLight;
using Apricot.WebServices.Plant;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows information of variety of a plant.
    /// </summary>
    public class VarietyDetailsViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Variety plant service.
        /// </summary>
        private readonly VarietyPlantService _varietyPlantService;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Get or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for OnLoaded event</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Get or sets a command for <code>OnUnloaded</code> event.
        /// </summary>
        /// <value>The command for OnUnloaded event</value>
        public ICommand OnUnloadedCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public VarietyDetailsModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public VarietyDetailsViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _varietyPlantService = new VarietyPlantService();

                // Initialize properties.
                Model = new VarietyDetailsModel();

                // Register messengers.
                MessengerInstance.Register<int>(this, _OnPlantIdentifierMessage);
            }
        }

        #endregion Constructors.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Receives the plant identifier.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        private void _OnPlantIdentifierMessage(int varietyIdentifier)
        {
            _LoadVarietyInformationAsync(varietyIdentifier);
        }

        #endregion Events.

        /// <summary>
        ///     Loads the variety information.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        private async void _LoadVarietyInformationAsync(int varietyIdentifier)
        {
            Model.Details = await _varietyPlantService.GetDetailsAsync(varietyIdentifier);
        }

        #endregion Methods.
    }
}