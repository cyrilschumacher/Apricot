using Apricot.Shared.Models.Services;
using Apricot.Shared.Models.ViewModels;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for shows variety information.
    /// </summary>
    public class VarietyInformationSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public VarietyInformationModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public VarietyInformationSampleData()
        {
            Model = new VarietyInformationModel
            {
                Information = new VarietyDetailsServiceModel
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
