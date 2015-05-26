using System.Collections.Generic;
using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    ///     Model for create a new plant.
    /// </summary>
    public class CreatePlantServiceModel
    {
        /// <summary>
        ///     Gets or sets a device identifier.
        /// </summary>
        [JsonProperty("idArd")]
        public string DeviceId { get; set; }

        /// <summary>
        ///     Gets or sets a plant name.
        /// </summary>
        /// <value>The plant name.</value>
        [JsonProperty("namePlant")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        [JsonProperty("idTypePlant")]
        public int VarietyId { get; set; }

        /// <summary>
        ///     Gets or sets a photos.
        /// </summary>
        /// <value>The a photos.</value>
        [JsonProperty("photosPlant")]
        public IEnumerable<string> Photos { get; set; } 
    }
}
