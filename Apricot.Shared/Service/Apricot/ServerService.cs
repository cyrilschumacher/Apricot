using System.Threading.Tasks;
using Apricot.Shared.Model.Service;

namespace Apricot.Shared.Service.Apricot
{
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
            return await GetResponse<ServerHealthModel>(ServerHealthServiceName);
        }

        #endregion Methods.
    }
}
