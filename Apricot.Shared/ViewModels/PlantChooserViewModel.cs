using System;
using System.Linq;
using System.Threading.Tasks;
using Apricot.Shared.Extensions;
using Apricot.Shared.Services;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Apricot.Shared.Models.Services;
using Apricot.Shared.Models.ViewModels;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for select an existing plant.
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

        #region Events.

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private async void _OnLoadedAsync()
        {
            // Indicates that loading occurs.
            Model.IsLoading = true;

            try
            {
                // Obtains a list of existing plants and determines the favorite plants.
                await _LoadPlantAsync();
                // The favorites list is to be made after loading the list of existing plants.
                _LoadFavoritePlant();
            }
            catch (Exception)
            {
                //todo: Manage error.
            }
            finally
            {
                Model.IsLoading = false;
            }
        }

        #endregion Events.

        /// <summary>
        ///     Loads existing plant.
        /// </summary>
        private async Task _LoadPlantAsync()
        {
            var plant = await _plantService.GetPlantsAsync();

            // Clear and adds existing plant.
            Model.Plant.Clear();
            Model.Plant.AddRange(plant);
        }

        /// <summary>
        ///     Loads favorites plant.
        /// </summary>
        private void _LoadFavoritePlant()
        {
            // Selects only the plants that have been saved as favorites.
            var idsFavorite = _plantFavoriteService.Get();
            var favorites = (from x in Model.Plant join y in idsFavorite on x.Identifier equals y select x).ToList();

            // Determines whether there favorites.
            Model.HasFavorites = favorites.Count > 0;

            // Clear and adds existing favorite plant.
            Model.Favorites.Clear();
            Model.Favorites.AddRange(favorites);
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