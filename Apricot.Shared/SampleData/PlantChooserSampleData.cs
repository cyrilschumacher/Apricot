using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apricot.Shared.Model;
using Apricot.Shared.Model.Service;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for the "Plant chooser" view.
    /// </summary>
    public class PlantChooserSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public PlantChooserModel Model { get; private set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantChooserSampleData()
        {
            Model = new PlantChooserModel
            {
                Plant = new ObservableCollection<PlantServiceModel>
                {
                    new PlantServiceModel{Id = "5560eba2e1a1798fb9edd09f", Name = "ut duis", Variety = 3},
                    new PlantServiceModel{Id = "5560eba236e1ff544bb6eaf6", Name = "nostrud id", Variety = 11},
                    new PlantServiceModel{Id = "5560eba25de8b401a33533aa", Name = "excepteur sunt", Variety = 4}
                },
                Favorites = new ObservableCollection<PlantServiceModel>
                {
                    new PlantServiceModel{Id = "5560eba2e1a1798fb9edd09f", Name = "ut duis", Variety = 3}
                }
            };
        }

        #endregion Constructors.
    }
}