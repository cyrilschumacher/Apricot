using Apricot.WebServices.Models.Server;
using System.Threading.Tasks;

namespace Apricot.WebServices.Server
{
    /// <summary>
    ///     Server service.
    /// </summary>
    public class ServerService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the health of server.
        /// </summary>
        private const string ServerHealthServiceName = "/";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get health of server.
        /// </summary>
        /// <returns>The health server.</returns>
        public async Task<ServerHealthModel> GetHealthAsync()
        {
            return await GetAsync<ServerHealthModel>(ServerHealthServiceName);
        }

        #endregion Methods.
    }
}