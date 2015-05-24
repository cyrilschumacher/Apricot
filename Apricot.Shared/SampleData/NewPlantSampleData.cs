using Windows.Phone.UI.Input;
using Apricot.Shared.Model;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for the "New plant" view.
    /// </summary>
    public class NewPlantSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public NewPlantModel Model { get; private set; }

        #endregion Properties.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public NewPlantSampleData()
        {
            Model = new NewPlantModel
            {
                Name = "Etiam vulputate purus",
                Variety = new object[] { "In pharetra", "Pharetra mattis", "Rhoncus facilisis", "Egestas lacus" }
            };
        }

        #endregion Constructor.
    }
}