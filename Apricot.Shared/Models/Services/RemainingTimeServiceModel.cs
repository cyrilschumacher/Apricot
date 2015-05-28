using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    ///     Model for the time remaining before watering.
    /// </summary>
    public class RemainingTimeServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a time remaining (in seconds).
        /// </summary>
        /// <value>The time in seconds.</value>
        [JsonProperty("time")]
        public long LeftTime { get; set; }

        #endregion Properties.
    }
}
