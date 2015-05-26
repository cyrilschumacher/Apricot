using System.Linq;
using System.Threading.Tasks;
using Apricot.Shared.Extensions;
using Apricot.Shared.Models;
using Apricot.Shared.Services;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Apricot.Shared.Models.Service;

namespace Apricot.Shared.ViewModels
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
                Model = new PlantChooserModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoadedAsync),
                    SelectPlantCommand = new RelayCommand<PlantServiceModel>(_SelectPlant)
                };
            }
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Loads existing plant.
        /// </summary>
        private async Task _LoadPlantAsync()
        {
            var plant = await _plantService.GetPlant();

            Model.Plant.Clear();
            Model.Plant.AddRange(plant);
        }

        /// <summary>
        ///     Loads favorites plant.
        /// </summary>
        private void _LoadFavoritePlant()
        {
            var idsFavorite = _plantFavoriteService.Get();
            var favorites = (from x in Model.Plant join y in idsFavorite on x.Id equals y select x).ToList();

            Model.Favorites.Clear();
            Model.Favorites.AddRange(favorites);
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private async void _OnLoadedAsync()
        {
            await _LoadPlantAsync();
            _LoadFavoritePlant();
        }

        /// <summary>
        ///     Select a plant.
        /// </summary>
        /// <param name="plant">The plant selectionned.</param>
        private void _SelectPlant(PlantServiceModel plant)
        {
            _navigationService.NavigateTo("Plant");
            MessengerInstance.Send(plant);
        }

        #endregion Methods.
    }
}