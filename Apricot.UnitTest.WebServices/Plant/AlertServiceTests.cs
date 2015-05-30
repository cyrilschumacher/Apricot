using System.Threading.Tasks;
using Apricot.WebServices.Plant;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Apricot.UnitTest.WebServices.Plant
{
    /// <summary>
    ///     Tests for <see cref="AlertService" /> class.
    /// </summary>
    [TestClass]
    public class AlertServiceTests
    {
        #region Members.

        /// <summary>
        ///     Alert service.
        /// </summary>
        private readonly AlertService _alertService;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public AlertServiceTests()
        {
            _alertService = new AlertService();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Test for the <see cref="AlertService.GetAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetTestAsync()
        {
            var result = await _alertService.GetAsync(0);
            Assert.IsNotNull(result, "The result is null.");
        }

        /// <summary>
        ///     Test for the <see cref="AlertService.GetTimeRemainingAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetTimeRemainingTestAsync()
        {
            var result = await _alertService.GetTimeRemainingAsync(0);
            Assert.IsNotNull(result, "The result is null.");
        }

        #endregion Methods.
    }
}