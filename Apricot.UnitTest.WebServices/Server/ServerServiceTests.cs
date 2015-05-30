using System.Threading.Tasks;
using Apricot.WebServices.Server;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Apricot.UnitTest.WebServices.Server
{
    /// <summary>
    ///     Tests for <see cref="ServerService" /> class.
    /// </summary>
    [TestClass]
    public class ServerServiceTests
    {
        #region Members.

        /// <summary>
        ///     Server service.
        /// </summary>
        private readonly ServerService _serverService;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public ServerServiceTests()
        {
            _serverService = new ServerService();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Test for the <see cref="ServerService.GetHealthAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetAllTestAsync()
        {
            var result = await _serverService.GetHealthAsync();
            Assert.IsNotNull(result, "The model is null.");
        }

        #endregion Methods.
    }
}
