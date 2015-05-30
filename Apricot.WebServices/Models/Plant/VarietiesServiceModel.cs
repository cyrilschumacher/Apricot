using Newtonsoft.Json;

namespace Apricot.WebServices.Models.Plant
{
    /// <summary>
    ///     Model for variety plant.
    /// </summary>
    public class VarietiesServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("idTypePlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets a name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("nameTypePlant")]
        public string Name { get; set; }

        #endregion Properties.
    }
}
