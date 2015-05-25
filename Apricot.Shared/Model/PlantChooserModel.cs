using System.Collections.ObjectModel;
using System.Windows.Input;
using Apricot.Shared.Model.Service;

namespace Apricot.Shared.Model
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
        ///     Plant.
        /// </summary>
        private ObservableCollection<PlantServiceModel> _plant;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets favorites plant.
        /// </summary>
        public ObservableCollection<PlantServiceModel> Favorites
        {
            get { return _favorites; }
            set { SetValueProperty(ref _favorites, value); }
        }

        /// <summary>
        ///     Command for OnLoaded event.
        /// </summary>
        public ICommand OnLoadedCommand { get; set; }

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