using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Apricot.Shared.Models.Services
{
    /// <summary>
    ///     Model for obtains the details of plant.
    /// </summary>
    public class PlantDetailsServiceModel : NotifyPropertyChanged
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets the plant identifier.
        /// </summary>
        /// <value>The plant identifier.</value>
        [JsonProperty("idPlant")]
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        [JsonProperty("photoPlant")]
        public List<string> Photos { get; set; }

        /// <summary>
        ///     Gets or sets the variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        [JsonProperty("idTypePlant")]
        public int Variety { get; set; }

        #endregion Properties.
    }
}
