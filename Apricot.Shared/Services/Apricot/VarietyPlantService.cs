using System.Collections.Generic;
using System.Threading.Tasks;
using Apricot.Shared.Models.Services;

namespace Apricot.Shared.Services.Apricot
{
    /// <summary>
    ///     Service to manage plant varieties.
    /// </summary>
    public class VarietyPlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the variety plant list.
        /// </summary>
        private const string VarietiesServiceName = "getTypePlant";

        /// <summary>
        ///     Service name for obtains the information of variety.
        /// </summary>
        private const string VarietyDetailsServiceName = "getTypePlant/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get varieties.
        /// </summary>
        /// <returns>The varieties.</returns>
        public async Task<List<VarietiesServiceModel>> GetVarieties()
        {
            return await GetAsync<List<VarietiesServiceModel>>(VarietiesServiceName);
        }

        /// <summary>
        ///     Get variety details.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        /// <returns>The information variety of plant.</returns>
        public async Task<VarietyDetailsServiceModel> GetVarietyDetails(int varietyIdentifier)
        {
            var serviceUri = string.Format(VarietyDetailsServiceName, varietyIdentifier);
            return await GetAsync<VarietyDetailsServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}
