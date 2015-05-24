using Apricot.Shared.Model;
using Apricot.Shared.Service;
using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Linq;
using System.Threading.Tasks;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     View model for the "Plant chooser" view.
    /// </summary>
    public class PlantChooserViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

        /// <summary>
        ///     Favorite plant management service.
        /// </summary>
        private readonly PlantFavoriteService _plantFavoriteService;

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
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _navigationService = navigationService;
                _plantService = new PlantService();
                _plantFavoriteService = new PlantFavoriteService();

                // Initialize properties.
                Model = new PlantChooserModel();
                _InitializeCommands();
            }
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Initialize commands.
        /// </summary>
        private void _InitializeCommands()
        {
            Model.OnLoadedCommand = new RelayCommand(_OnLoaded);
        }

        /// <summary>
        ///     Loads existing plant.
        /// </summary>
        private async Task _LoadPlant()
        {
            Model.Plant = await _plantService.GetPlant();
        }

        /// <summary>
        ///     Loads favorites plant.
        /// </summary>
        private void _LoadFavoritePlant()
        {
            var favorites = _plantFavoriteService.Get();
            Model.Favorites = (from x in Model.Plant join y in favorites on x.Id equals y select x).ToList();
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private async void _OnLoaded()
        {
            await _LoadPlant();
            _LoadFavoritePlant();
        }

        #endregion Methods.
    }
}