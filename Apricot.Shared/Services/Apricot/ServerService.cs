using System.Threading.Tasks;
using Apricot.Shared.Models.Service;
using Apricot.Shared.Services.Apricot;

namespace Apricot.Shared.Services.Apricot
{
    /// <summary>
    ///     Server service.
    /// </summary>
    public class ServerService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the details of a plant.
        /// </summary>
        private const string ServerHealthServiceName = "server/health";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get health of server.
        /// </summary>
        /// <returns>The health server.</returns>
        public async Task<ServerHealthModel> GetHealth()
        {
            return await GetAsync<ServerHealthModel>(ServerHealthServiceName);
        }

        #endregion Methods.
    }
}