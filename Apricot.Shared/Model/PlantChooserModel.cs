using System;
using System.Collections.Generic;

namespace Apricot.Shared.Model
{
    /// <summary>
    ///     Model for plant chooser view.
    /// </summary>
    public class PlantChooserModel : NotifyPropertyChanged
    {
        #region Members.

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets favorite plant.
        /// </summary>
        public List<Object> Favorites { get; set; }

        /// <summary>
        ///     Gets or sets plant.
        /// </summary>
        public List<Object> Plant { get; set; }

        #endregion Properties.
    }
}