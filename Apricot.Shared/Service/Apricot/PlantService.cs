using System;
using System.Threading.Tasks;

namespace Apricot.Shared.Service.Apricot
{
    /// <summary>
    ///     Apricote Plant service.
    /// </summary>
    public class PlantService : AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Service name for obtains the details of a plant.
        /// </summary>
        private const string DetailsPlantServiceName = "plant";
        
        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get details of a plant.
        /// </summary>
        /// <returns>Details of a plant.</returns>
        public async Task GetPlant()
        {
            await GetResponse<Object>(DetailsPlantServiceName);
        }

        #endregion Methods.
    }
}
