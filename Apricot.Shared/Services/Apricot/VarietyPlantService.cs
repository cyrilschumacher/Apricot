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
        private const string VarietyPlantListServiceName = "getTypePlant";

        /// <summary>
        ///     Service name for obtains the information of variety.
        /// </summary>
        private const string VarietyPlantServiceName = "getTypePlant/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get a list of plant varieties.
        /// </summary>
        /// <returns>The list of plant varieties.</returns>
        public async Task<List<VarietyPlantServiceModel>> GetVarieties()
        {
            return await GetAsync<List<VarietyPlantServiceModel>>(VarietyPlantListServiceName);
        }

        /// <summary>
        ///     Get information variety.
        /// </summary>
        /// <returns>The information variety of plant.</returns>
        public async Task<VarietyPlantInformationServiceModel> GetVarietyInformation(int plantId)
        {
            var serviceUri = string.Format(VarietyPlantServiceName, plantId);
            return await GetAsync<VarietyPlantInformationServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}
