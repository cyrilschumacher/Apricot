using Apricot.Shared.Models;
using Apricot.Shared.Models.Services;
using System.Collections.ObjectModel;

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
                    new PlantServiceModel{Identifier = 0, Name = "ut duis" },
                    new PlantServiceModel{Identifier = 1, Name = "nostrud id" },
                    new PlantServiceModel{Identifier = 2, Name = "excepteur sunt" }
                },
                Favorites = new ObservableCollection<PlantServiceModel>
                {
                    new PlantServiceModel{Identifier = 0, Name = "ut duis" }
                }
            };
        }

        #endregion Constructors.
    }
}