using System.Collections.Generic;
using System.Threading.Tasks;
using Apricot.Shared.Models.Services;

namespace Apricot.Shared.Services.Apricot
{
    /// <summary>
    /// </summary>
    public class MeasureService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains all temperature, luminosity and humidity of the plant.
        /// </summary>
        private const string AllMeasureServiceName = "getValue/last/{0}/{1}";

        /// <summary>
        ///     Service name for obtains temperature, luminosity and humidity of the plant.
        /// </summary>
        private const string LastMeasureServiceName = "getValue/last/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Gets the latest measure of the plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The latest measure.</returns>
        public async Task<MeasureServiceModel> GetLast(int plantIdentifier)
        {
            var serviceUri = string.Format(LastMeasureServiceName, plantIdentifier);
            return await GetAsync<MeasureServiceModel>(serviceUri);
        }

        /// <summary>
        ///     Gets the all measures of the plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <param name="numberHours">The number of hours.</param>
        /// <returns>The all measures.</returns>
        public async Task<List<MeasureServiceModel>> GetAll(int plantIdentifier, int numberHours)
        {
            var serviceUri = string.Format(AllMeasureServiceName, plantIdentifier, numberHours);
            return await GetAsync<List<MeasureServiceModel>>(serviceUri);
        }

        #endregion Methods.
    }
}
