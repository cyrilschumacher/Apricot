using Apricot.WebServices.Models.Plant;
using System.Threading.Tasks;

namespace Apricot.WebServices.Plant
{
    /// <summary>
    ///     Service for manage alert.
    /// </summary>
    public class AlertService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the time remaining before the next watering is done.
        /// </summary>
        private const string AlertServiceName = "getAlert/Plant/{0}";

        /// <summary>
        ///     Service name for obtains the time remaining before the next watering is done.
        /// </summary>
        private const string TimeRemainingServiceName = "getAlert/watering/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Gets the alert information by a plant identifier.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The alert information.</returns>
        public async Task<AlertServiceModel> GetAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(AlertServiceName, plantIdentifier);
            return await GetAsync<AlertServiceModel>(serviceUri);
        }

        /// <summary>
        ///     Gets the time remaining before the new watering is done.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The time remaining before watering.</returns>
        public async Task<RemainingTimeServiceModel> GetTimeRemainingAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(TimeRemainingServiceName, plantIdentifier);
            return await GetAsync<RemainingTimeServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}