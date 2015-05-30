using System.Threading.Tasks;
using Apricot.WebServices.Plant;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Apricot.UnitTest.WebServices.Plant
{
    /// <summary>
    ///     Tests for <see cref="MeasureService" /> class.
    /// </summary>
    [TestClass]
    public class MeasureServiceTests
    {
        #region Members.

        /// <summary>
        ///     Measure service.
        /// </summary>
        private readonly MeasureService _measureService;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MeasureServiceTests()
        {
            _measureService = new MeasureService();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Test for the <see cref="MeasureService.GetAll"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetAllTestAsync()
        {
            var result = await _measureService.GetAll(0, 1);
            Assert.IsNotNull(result, "The model is null.");
        }

        /// <summary>
        ///     Test for the <see cref="MeasureService.GetLast"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetLastTestAsync()
        {
            var result = await _measureService.GetLast(0);
            Assert.IsNotNull(result, "The model is null.");
        }

        #endregion Methods.
    }
}
