using System.Linq;
using System.Threading.Tasks;
using Apricot.Shared.Extension;
using Apricot.Shared.Model;
using Apricot.Shared.Service;
using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     View model for the "Plant chooser" view.
    /// </summary>
    public class PlantChooserViewModel : ViewModelBase
    {
        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantChooserViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _plantService = new PlantService();
                _plantFavoriteService = new PlantFavoriteService();

                // Initialize properties.
                Model = new PlantChooserModel
                {
                    OnLoadedCommand = new RelayCommand(_OnLoadedAsync)
                };
            }
        }

        #endregion Constructors.

        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public PlantChooserModel Model { get; private set; }

        #endregion Properties.

        #region Members.

        /// <summary>
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

        /// <summary>
        ///     Favorite plant management service.
        /// </summary>
        private readonly PlantFavoriteService _plantFavoriteService;

        #endregion Members.

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
            Model.Favorites.AddUnique(favorites);
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private async void _OnLoadedAsync()
        {
            await _LoadPlantAsync();
            _LoadFavoritePlant();
        }

        #endregion Methods.
    }
}