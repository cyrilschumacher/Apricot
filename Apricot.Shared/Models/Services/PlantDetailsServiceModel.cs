using System.Collections.Generic;
using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PlantDetailsServiceModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets the plant identifier.
        /// </summary>
        /// <value>The plant identifier.</value>
        [JsonProperty("idTypePlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        [JsonProperty("photoPlant")]
        public string Photo { get; set; }

        /// <summary>
        ///     Gets or sets the variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        [JsonProperty("idTypePlant")]
        public int Variety { get; set; }

        #endregion Properties.
    }
}
