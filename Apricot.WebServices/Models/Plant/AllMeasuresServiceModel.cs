using Newtonsoft.Json;

namespace Apricot.WebServices.Models.Plant
{
    /// <summary>
    ///     Model for obtains all measures.
    /// </summary>
    public class AllMeasuresServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a key.
        /// </summary>
        /// <value>The key that identify the measure.</value>
        [JsonProperty("key")]
        public int Key { get; set; }

        /// <summary>
        ///     Gets or sets measure.
        /// </summary>
        /// <value>The measure.</value>
        [JsonProperty("tab")]
        public MeasureServiceModel Measure { get; set; }

        #endregion Properties.
    }
}