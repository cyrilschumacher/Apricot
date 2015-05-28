using System.Threading.Tasks;
using Apricot.Shared.Models.Services;
using Apricot.Shared.Services.Apricot;

namespace Apricot.Shared.Services
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
        private const string GetAlertServiceName = "getAlert/watering/{0}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Gets the alert by <paramref name="plantIdentifier"/>.
        /// </summary>
        /// <param name="plantIdentifier">The plant identifier.</param>
        /// <returns>The time remaining before watering.</returns>
        public async Task<AlertServiceModel> GetByPlantIdentifierAsync(int plantIdentifier)
        {
            var serviceUri = string.Format(GetAlertServiceName, plantIdentifier);
            return await GetAsync<AlertServiceModel>(serviceUri);
        }

        #endregion Methods.
    }
}
