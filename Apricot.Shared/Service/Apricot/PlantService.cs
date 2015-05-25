using System;
using Apricot.Shared.Model.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Apricot.Shared.Service.Apricot
{
    /// <summary>
    ///     Apricote Plant service.
    /// </summary>
    public class PlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the details of a plant.
        /// </summary>
        private const string DetailsPlantServiceName = "getPlant";

        /// <summary>
        ///     Service name for obtains the variety plant list.
        /// </summary>
        private const string VarietyPlantListServiceName = "getTypesPlant";

        /// <summary>
        ///     Service name for creates a new plant.
        /// </summary>
        private const string CreateNewPlantServiceName = "setNewPlant";

        /// <summary>
        ///     Service name for stops a plant.
        /// </summary>
        private const string StopPlantServiceName = "stopPlant/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get details of a plant.
        /// </summary>
        /// <returns>The details of a plant.</returns>
        public async Task<List<PlantServiceModel>> GetPlant()
        {
            return await GetAsync<List<PlantServiceModel>>(DetailsPlantServiceName);
        }

        /// <summary>
        ///     Get a list of plant varieties.
        /// </summary>
        /// <returns>The list of plant varieties.</returns>
        public async Task<List<VarietyPlantServiceModel>> GetPlantVarieties()
        {
            return await GetAsync<List<VarietyPlantServiceModel>>(VarietyPlantListServiceName);
        }

        /// <summary>
        ///     Creates a new plant.
        /// </summary>
        /// <param name="plantName">The plant name.</param>
        /// <param name="varietyId">The variety identifier.</param>
        /// <param name="photos">The photos.</param>
        /// <returns>The task.</returns>
        public async Task CreateNewPlant(string plantName, string varietyId, IEnumerable<string> photos)
        {
            var model = new CreatePlantServiceModel {Name = plantName, Photos = photos, VarietyId = varietyId};
            var content = JsonConvert.SerializeObject(model);

            await PostAsync(CreateNewPlantServiceName, content);
        }

        /// <summary>
        ///     Stops plant.
        /// </summary>
        /// <param name="plantId">The plant identifier.</param>
        /// <returns>The task.</returns>
        public async Task StopPlant(string plantId)
        {
            var serviceUri = string.Format(StopPlantServiceName, plantId);
            await GetAsync(serviceUri);
        }

        #endregion Methods.
    }
}