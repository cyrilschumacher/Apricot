using System;
using Apricot.WebServices.Models.Plant;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apricot.WebServices.Extensions;
using Newtonsoft.Json;

namespace Apricot.WebServices.Plant
{
    /// <summary>
    ///     Service for the manager of plants.
    /// </summary>
    public class PlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for creates a new plant.
        /// </summary>
        private const string CreateServiceName = "setNewPlant";

        /// <summary>
        ///     Service name for obtains the details of a plant.
        /// </summary>
        private const string DetailsServiceName = "getPlant/{0}";

        /// <summary>
        ///     Service name for plant list.
        /// </summary>
        private const string PlantsServiceName = "getPlant";

        /// <summary>
        ///     Service name for stops a plant.
        /// </summary>
        private const string StopServiceName = "stopPlant/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Gets plant list.
        /// </summary>
        /// <returns>The list of plant.</returns>
        public async Task<List<PlantServiceModel>> GetAsync()
        {
            return await GetAsync<List<PlantServiceModel>>(PlantsServiceName);
        }

        /// <summary>
        ///     Gets details of a plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The details of a plant.</returns>
        public async Task<PlantDetailsServiceModel> GetDetailsAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(DetailsServiceName, plantIdentifier);
            return await GetAsync<PlantDetailsServiceModel>(serviceUri);
        }

        /// <summary>
        ///     Creates a new plant.
        /// </summary>
        /// <param name="plantName">The plant name.</param>
        /// <param name="deviceIdentifier">The device identifier.</param>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        /// <param name="photos">The photo list encoded base64.</param>
        /// <returns>The task.</returns>
        public async Task CreateAsync(string plantName, string deviceIdentifier, int varietyIdentifier, IList<string> photos)
        {
            if (string.IsNullOrEmpty(plantName))
            {
                throw new ArgumentNullException("plantName", "The parameter is null or empty.");
            }
            if (string.IsNullOrEmpty(deviceIdentifier))
            {
                throw new ArgumentNullException("deviceIdentifier", "The parameter is null or empty.");
            }
            if (photos.Any(string.IsNullOrWhiteSpace) || photos.Any(photo => !photo.IsValidBase64()))
            {
                throw new ArgumentException("A photo is empty, null or not encoded in Base64 properly.", "photos");
            }

            var model = new CreatePlantServiceModel { Name = plantName, DeviceId = deviceIdentifier, Photos = photos, VarietyId = varietyIdentifier };
            var content = JsonConvert.SerializeObject(model);

            await PostAsync(CreateServiceName, content);
        }

        /// <summary>
        ///     Stops plant.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The task.</returns>
        public async Task StopAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(StopServiceName, plantIdentifier);
            await GetAsync(serviceUri);
        }

        #endregion Methods.
    }
}