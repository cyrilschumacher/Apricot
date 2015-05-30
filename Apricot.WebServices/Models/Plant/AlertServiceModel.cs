using Newtonsoft.Json;

namespace Apricot.WebServices.Models.Plant
{
    /// <summary>
    ///     Model for obtains alerts on humidity and temperature.
    /// </summary>
    public class AlertServiceModel
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the plant is maintained at proper temperature.
        /// </summary>
        /// <value>True if the plant is at the right temperature, otherwise, False.</value>
        [JsonProperty("isHumidityGood")]
        public bool Humidity { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the plant is has good humidity.
        /// </summary>
        /// <value>True if the plant is has good humidity, otherwise, False.</value>
        [JsonProperty("isTemperatureGood")]
        public bool Temperature { get; set; }
    }
}
