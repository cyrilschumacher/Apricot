﻿using Newtonsoft.Json;

namespace Apricot.WebServices.Models.Plant
{
    /// <summary>
    ///     Model for information from the variety of the plant.
    /// </summary>
    public class VarietyDetailsServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a plant identifier.
        /// </summary>
        [JsonProperty("idTypePlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets a plant name.
        /// </summary>
        [JsonProperty("nameTypePlant")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a minimum temperature.
        /// </summary>
        [JsonProperty("minTempNeedPlant")]
        public int MinimumTemperature { get; set; }

        /// <summary>
        ///     Gets or sets a maximum temperature.
        /// </summary>
        [JsonProperty("maxTempNeedPlant")]
        public int MaximumTemperature { get; set; }

        /// <summary>
        ///     Gets or sets a minimum humidity.
        /// </summary>
        [JsonProperty("minHumidityNeedPlant")]
        public int MinimumHumidity { get; set; }

        /// <summary>
        ///     Gets or sets a maximum humidity.
        /// </summary>
        [JsonProperty("maxHumidityNeedPlant")]
        public int MaximumHumidity { get; set; }

        #endregion Properties.
    }
}
