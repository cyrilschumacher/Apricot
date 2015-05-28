using System.Threading.Tasks;
using Apricot.Shared.Models.Services;

namespace Apricot.Shared.Services.Apricot
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
        private const string GetTimeRemainingServiceName = "getAlert/watering/{0}";

        /// <summary>
        ///     Service name for obtains the time remaining before the next watering is done.
        /// </summary>
        private const string GetAlertServiceName = "getAlert/Plant/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Gets the alert information by a plant identifier.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The alert information.</returns>
        public async Task<AlertServiceModel> GetAlertAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(GetAlertServiceName, plantIdentifier);
            return await GetAsync<AlertServiceModel>(serviceUri);
        }

        /// <summary>
        ///     Gets the time remaining before the new watering is done.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The time remaining before watering.</returns>
        public async Task<RemainingTimeServiceModel> GetTimeRemainingAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(GetTimeRemainingServiceName, plantIdentifier);
            return await GetAsync<RemainingTimeServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}
