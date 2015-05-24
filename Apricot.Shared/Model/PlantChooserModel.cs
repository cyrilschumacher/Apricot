using Apricot.Shared.Model.Service;
using System.Collections.Generic;
using System.Windows.Input;

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
        private IList<PlantModel> _favorites;

        /// <summary>
        ///     Plant.
        /// </summary>
        private IList<PlantModel> _plant;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets favorites plant.
        /// </summary>
        public IList<PlantModel> Favorites
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
        ///     Command for OnLoaded event.
        /// </summary>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets plant.
        /// </summary>
        public IList<PlantModel> Plant
        {
            get
            {
                return _plant;
            }
            set
            {
                SetValueProperty(ref _plant, value);
            }
        }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantChooserModel()
        {
            Favorites = new List<PlantModel>();
            Plant = new List<PlantModel>();
        }

        #endregion Constructors.
    }
}