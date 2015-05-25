using Apricot.Shared.Model;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for the "Plant information" view.
    /// </summary>
    public class PlantSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        public PlantModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantSampleData()
        {
            // Initialize properties.
            Model = new PlantModel();
        }

        #endregion Constructors.
    }
}