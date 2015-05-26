using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    /// </summary>
    public class MeasureServiceModel
    {
        /// <summary>
        ///     Gets or sets a date.
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty("timestamp")]
        public string Date { get; set; }

        /// <summary>
        ///     Gets or sets a humidity.
        /// </summary>
        /// <value>The humidity.</value>
        [JsonProperty("humidityPlant")]
        public int Humidity { get; set; }

        /// <summary>
        ///     Gets or sets a luminosity.
        /// </summary>
        /// <value>The luminosity.</value>
        [JsonProperty("sunnyPlant")]
        public int Luminosity { get; set; }

        /// <summary>
        ///     Gets or sets a temperature.
        /// </summary>
        /// <value>The temperature.</value>
        [JsonProperty("tempPlant")]
        public double Temperature { get; set; }
    }
}