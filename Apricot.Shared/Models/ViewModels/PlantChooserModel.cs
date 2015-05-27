using Apricot.Shared.Models.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        #region Commands.

        /// <summary>
        ///     Gets or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for <code>OnLoaded</code> event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for select a plant.
        /// </summary>
        /// <value>The command for select a plant.</value>
        public RelayCommand<PlantServiceModel> SelectPlantCommand { get; set; }

        #endregion Commands.

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