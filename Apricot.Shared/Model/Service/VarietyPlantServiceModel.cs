using Newtonsoft.Json;

namespace Apricot.Shared.Model.Service
{
    public class VarietyPlantServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("idTypePlant")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets a name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("nameTypePlant")]
        public string Name { get; set; }

        #endregion Properties.
    }
}
