using Apricot.Shared.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Apricot.Shared.Services.Apricot
{
    /// <summary>
    ///     Service for the manager of plants.
    /// </summary>
    public class PlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for plant list.
        /// </summary>
        private const string PlantListServiceName = "getPlant";

        /// <summary>
        ///     Service name for obtains the details of a plant.
        /// </summary>
        private const string DetailsPlantServiceName = "getPlant/{0}";

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
        ///     Gets plant list.
        /// </summary>
        /// <returns>The list of plant.</returns>
        public async Task<List<PlantServiceModel>> GetPlantsAsync()
        {
            return await GetAsync<List<PlantServiceModel>>(PlantListServiceName);
        }

        /// <summary>
        ///     Gets details of a plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The details of a plant.</returns>
        public async Task<PlantDetailsServiceModel> GetDetailsPlantAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(DetailsPlantServiceName, plantIdentifier);
            return await GetAsync<PlantDetailsServiceModel>(serviceUri);
        }

        /// <summary>
        ///     Creates a new plant.
        /// </summary>
        /// <param name="plantName">The plant name.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="varietyId">The variety identifier.</param>
        /// <param name="photos">The photos.</param>
        /// <returns>The task.</returns>
        public async Task CreateNewPlantAsync(string plantName, string deviceId, int varietyId, IEnumerable<string> photos)
        {
            var model = new CreatePlantServiceModel {Name = plantName, DeviceId = deviceId, Photos = photos, VarietyId = varietyId};
            var content = JsonConvert.SerializeObject(model);

            await PostAsync(CreateNewPlantServiceName, content);
        }

        /// <summary>
        ///     Stops plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The task.</returns>
        public async Task StopPlantAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(StopPlantServiceName, plantIdentifier);
            await GetAsync(serviceUri);
        }

        #endregion Methods.
    }
}