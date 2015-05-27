using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
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
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets a name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("nameTypePlant")]
        public string Name { get; set; }

        #endregion Properties.
    }
}
