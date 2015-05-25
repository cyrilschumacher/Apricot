using System.Collections.Generic;
using Windows.Storage;

namespace Apricot.Shared.Services
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

        #region Private methods.

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

        #endregion Private methods.

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
        ///     Determines whether a plant was set as a favorite. 
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        /// <returns>True if the plant is favorite, otherwise, False.</returns>
        public bool Exists(string id)
        {
            var favorites = _GetFavorites();
            return favorites.Contains(id);
        }

        /// <summary>
        ///     Gets plant favorites.
        /// </summary>
        /// <returns>The plant favorites.</returns>
        public IList<string> Get()
        {
            return _GetFavorites();
        }

        /// <summary>
        ///     Removes a plant in the favorites.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        public void Remove(string id)
        {
            var favorites = _GetFavorites();
            favorites.Remove(id);

            _settingsDataContainer.Values[PlantFavoritesSettingsName] = favorites;
        }

        #endregion Methods.
    }
}