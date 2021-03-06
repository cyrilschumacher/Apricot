﻿using System.Collections.ObjectModel;
using Apricot.WebServices.Models.Plant;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for the "Plant chooser" view.
    /// </summary>
    public class PlantChooserModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Favorites plant.
        /// </summary>
        private ObservableCollection<PlantServiceModel> _favorites;

        /// <summary>
        ///     Value indicating whether any existing favorites.
        /// </summary>
        private bool _hasFavorites;

        /// <summary>
        ///     Value indicating whether a load is in progress.
        /// </summary>
        private bool _isLoading;

        /// <summary>
        ///     Plant.
        /// </summary>
        private ObservableCollection<PlantServiceModel> _plant;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a value indicating whether any existing favorites.
        /// </summary>
        /// <value>True if exist favorites, otherwise, False.</value>
        public bool HasFavorites
        {
            get
            {
                return _hasFavorites;
            }
            set
            {
                SetValueProperty(ref _hasFavorites, value);
            }
        }

        /// <summary>
        ///     Gets or sets favorites plant.
        /// </summary>
        /// <value>Favorites plant.</value>
        public ObservableCollection<PlantServiceModel> Favorites
        {
            get
            {
                return _favorites;
            }
            set
            {
                SetValueProperty(ref _favorites, value);
            }
        }

        /// <summary>
        ///     Value indicating whether a load is in progress.
        /// </summary>
        /// <value>
        ///     <code>True</code> if a loading occurs, otherwise, <code>False</code>.
        /// </value>
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetValueProperty(ref _isLoading, value);
            }
        }

        /// <summary>
        ///     Gets or sets plant.
        /// </summary>
        public ObservableCollection<PlantServiceModel> Plant
        {
            get { return _plant; }
            set { SetValueProperty(ref _plant, value); }
        }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantChooserModel()
        {
            Favorites = new ObservableCollection<PlantServiceModel>();
            Plant = new ObservableCollection<PlantServiceModel>();
        }

        #endregion Constructors.
    }
}