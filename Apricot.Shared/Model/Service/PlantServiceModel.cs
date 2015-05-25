using Newtonsoft.Json;

namespace Apricot.Shared.Model.Service
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
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the plant name.
        /// </summary>
        /// <value>The plant name.</value>
        [JsonProperty("namePlant")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        [JsonProperty("idTypePlant")]
        public int Variety { get; set; }

        #endregion Properties.
    }
}