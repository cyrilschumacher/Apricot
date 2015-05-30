using Apricot.WebServices.Models.Plant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apricot.WebServices.Plant
{
    /// <summary>
    ///     Service to manage plant varieties.
    /// </summary>
    public class VarietyPlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the information of variety.
        /// </summary>
        private const string DetailsServiceName = "getTypePlant/{0}";

        /// <summary>
        ///     Service name for obtains the variety plant list.
        /// </summary>
        private const string VarietiesServiceName = "getTypePlant";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get varieties.
        /// </summary>
        /// <returns>The varieties.</returns>
        public async Task<List<VarietiesServiceModel>> GetAsync()
        {
            return await GetAsync<List<VarietiesServiceModel>>(VarietiesServiceName);
        }

        /// <summary>
        ///     Get variety details.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        /// <returns>The information variety of plant.</returns>
        public async Task<VarietyDetailsServiceModel> GetDetailsAsync(int varietyIdentifier)
        {
            var serviceUri = string.Format(DetailsServiceName, varietyIdentifier);
            return await GetAsync<VarietyDetailsServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}