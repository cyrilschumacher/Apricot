using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    ///     Model for the details of a plant.
    /// </summary>
    public class PlantServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets the plant identifier.
        /// </summary>
        /// <value>The plant identifier.</value>
        [JsonProperty("idPlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the plant name.
        /// </summary>
        /// <value>The plant name.</value>
        [JsonProperty("namePlant")]
        public string Name { get; set; }

        #endregion Properties.
    }
}