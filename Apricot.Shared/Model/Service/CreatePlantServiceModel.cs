using System.Collections.Generic;
using Newtonsoft.Json;

namespace Apricot.Shared.Model.Service
{
    /// <summary>
    ///     Model for create a new plant.
    /// </summary>
    public class CreatePlantServiceModel
    {
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
        public string VarietyId { get; set; }

        /// <summary>
        ///     Gets or sets a photos.
        /// </summary>
        /// <value>The a photos.</value>
        [JsonProperty("photosPlant")]
        public IEnumerable<string> Photos { get; set; } 
    }
}
