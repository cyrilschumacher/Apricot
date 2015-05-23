using Apricot.Shared.Model.Service;
using System.Collections.Generic;
using System.Windows.Input;

namespace Apricot.Shared.Model
{
    /// <summary>
    ///     Model for plant chooser view.
    /// </summary>
    public class PlantChooserModel : NotifyPropertyChanged
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets favorite plant.
        /// </summary>
        public IList<PlantModel> Favorites { get; set; }

        /// <summary>
        ///     Command for OnLoaded event.
        /// </summary>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets plant.
        /// </summary>
        public IList<PlantModel> Plant { get; set; }

        #endregion Properties.
    }
}