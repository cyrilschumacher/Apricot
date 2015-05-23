using System.Collections.Generic;
using Windows.Storage;

namespace Apricot.Shared.Service
{
    /// <summary>
    ///     Favorite plant management service.
    /// </summary>
    public class PlantFavoriteService
    {
        #region Constants.

        /// <summary>
        ///     Settings name that contains plant favorites.
        /// </summary>
        private const string PlantFavoritesSettingsName = "plantFavorites";

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     Settings data container.
        /// </summary>
        private readonly ApplicationDataContainer _settingsDataContainer;

        #endregion Members.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantFavoriteService()
        {
            _settingsDataContainer = ApplicationData.Current.LocalSettings;
        }

        #endregion Constructor.

        #region Methods.

        /// <summary>
        ///     Gets plant favorites.
        /// </summary>
        /// <returns>The plant favorites.</returns>
        private IList<string> _GetFavorites()
        {
            if (_settingsDataContainer.Values.ContainsKey(PlantFavoritesSettingsName))
            {
                return _settingsDataContainer.Values[PlantFavoritesSettingsName] as List<string>;
            }

            return new List<string>();
        }

        /// <summary>
        ///     Adds a plant in the favorites.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        public void Add(string id)
        {
            var favorites = _GetFavorites();
            favorites.Add(id);

            _settingsDataContainer.Values[PlantFavoritesSettingsName] = favorites;
        }

        /// <summary>
        ///     Remove a plant in the favorites.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        public void Remove(string id)
        {
            var favorites = _GetFavorites();
            favorites.Remove(id);

            _settingsDataContainer.Values[PlantFavoritesSettingsName] = favorites;
        }

        /// <summary>
        ///     Gets plant favorites.
        /// </summary>
        /// <returns>The plant favorites.</returns>
        public IList<string> Get()
        {
            return _GetFavorites();
        }

        #endregion Methods.
    }
}