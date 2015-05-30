using System.Collections.ObjectModel;
using Apricot.Shared.Models.ViewModels;
using Apricot.WebServices.Models.Plant;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for select an existing plant.
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