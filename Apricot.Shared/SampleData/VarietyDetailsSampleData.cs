using Apricot.Shared.Models.ViewModels;
using Apricot.WebServices.Models.Plant;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for shows variety information.
    /// </summary>
    public class VarietyDetailsSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public VarietyDetailsModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public VarietyDetailsSampleData()
        {
            Model = new VarietyDetailsModel
            {
                Details = new VarietyDetailsServiceModel
                {
                    Identifier = 0,
                    MaximumHumidity = 10,
                    MaximumTemperature = 40,
                    MinimumHumidity = 0,
                    MinimumTemperature = 0,
                    Name = "Mauris sollicitudin"
                }
            };
        }

        #endregion Constructors.
    }
}
