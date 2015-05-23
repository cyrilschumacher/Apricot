using System.Collections.Generic;
using Apricot.Shared.Model.Service;
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
        private const string DetailsPlantServiceName = "getPlant";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Get details of a plant.
        /// </summary>
        /// <returns>Details of a plant.</returns>
        public async Task<IList<PlantModel>> GetPlant()
        {
            return await Get<IList<PlantModel>>(DetailsPlantServiceName);
        }

        #endregion Methods.
    }
}