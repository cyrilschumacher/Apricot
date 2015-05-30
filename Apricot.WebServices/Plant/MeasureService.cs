using Apricot.WebServices.Models.Plant;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apricot.WebServices.Plant
{
    /// <summary>
    ///     Service for manage measures.
    /// </summary>
    public class MeasureService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains all temperature, luminosity and humidity of the plant.
        /// </summary>
        private const string AllMeasureServiceName = "getValue/all/{0}/{1}";

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
        public async Task<List<AllMeasuresServiceModel>> GetAll(int plantIdentifier, int numberHours)
        {
            var serviceUri = string.Format(AllMeasureServiceName, plantIdentifier, numberHours);
            return await GetAsync<List<AllMeasuresServiceModel>>(serviceUri, TimeSpan.FromSeconds(5));
        }

        #endregion Methods.
    }
}