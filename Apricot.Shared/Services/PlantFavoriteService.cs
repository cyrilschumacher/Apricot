using System;
using System.Collections.Generic;
using System.Linq;
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
        ///     Creates plant favorites.
        /// </summary>
        private void _CreateFavorites()
        {
            if (!_settingsDataContainer.Values.ContainsKey(PlantFavoritesSettingsName))
            {
                _settingsDataContainer.Values[PlantFavoritesSettingsName] = string.Empty;
            }
        }

        /// <summary>
        ///     Gets plant favorites.
        /// </summary>
        /// <returns>The plant favorites.</returns>
        private IList<int> _GetFavorites()
        {
            _CreateFavorites();

            var favorites = _settingsDataContainer.Values[PlantFavoritesSettingsName] as string;
            if (favorites == null)
            {
                throw new Exception("The favorite list couldn't be recovered.");
            }

            return
                favorites.Split(',')
                    .Where(identifier => !string.IsNullOrWhiteSpace(identifier))
                    .Select(int.Parse)
                    .ToList();
        }

        /// <summary>
        ///     Saves plant favorites.
        /// </summary>
        /// <param name="favorites">The plant favorites.</param>
        private void _SaveFavorites(IEnumerable<int> favorites)
        {
            _settingsDataContainer.Values[PlantFavoritesSettingsName] = string.Join(",", favorites);
        }

        #endregion Private methods.

        /// <summary>
        ///     Adds a plant in the favorites.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        public void Add(int id)
        {
            var favorites = _GetFavorites();
            favorites.Add(id);

            _SaveFavorites(favorites);
        }

        /// <summary>
        ///     Determines whether a plant was set as a favorite.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        /// <returns>True if the plant is favorite, otherwise, False.</returns>
        public bool Exists(int id)
        {
            var favorites = _GetFavorites();
            return favorites.Contains(id);
        }

        /// <summary>
        ///     Gets plant favorites.
        /// </summary>
        /// <returns>The plant favorites.</returns>
        public IList<int> Get()
        {
            return _GetFavorites();
        }

        /// <summary>
        ///     Removes a plant in the favorites.
        /// </summary>
        /// <param name="id">The plant identifier.</param>
        public void Remove(int id)
        {
            var favorites = _GetFavorites();
            favorites.Remove(id);

            _SaveFavorites(favorites);
        }

        #endregion Methods.
    }
}