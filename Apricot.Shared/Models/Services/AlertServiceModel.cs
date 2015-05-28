using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    //todo: Add documentation.
    public class AlertServiceModel
    {
        [JsonProperty("isHumidityGood")]
        public bool Humidity { get; set; }

        [JsonProperty("isTemperatureGood")]
        public bool Temperature { get; set; }
    }
}
