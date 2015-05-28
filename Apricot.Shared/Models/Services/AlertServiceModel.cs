using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    ///     Model for the time remaining before watering.
    /// </summary>
    public class AlertServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a time remaining.
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime LeftTime { get; set; }

        #endregion Properties.
    }
}
