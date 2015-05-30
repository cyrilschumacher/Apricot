using Newtonsoft.Json;

namespace Apricot.WebServices.Models.Plant
{
    /// <summary>
    ///     Model for the details of a plant.
    /// </summary>
    public class PlantServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a plant identifier.
        /// </summary>
        /// <value>The plant identifier.</value>
        [JsonProperty("idPlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets a value that indicates if the plant is active or not.
        /// </summary>
        /// <value>The value that indicates if the plant is active or not.</value>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a plant name.
        /// </summary>
        /// <value>The plant name.</value>
        [JsonProperty("namePlant")]
        public string Name { get; set; }

        #endregion Properties.
    }
}