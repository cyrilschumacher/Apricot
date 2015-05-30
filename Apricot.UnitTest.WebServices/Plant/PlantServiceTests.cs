using System.Collections.Generic;
using System.Threading.Tasks;
using Apricot.WebServices.Plant;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Apricot.UnitTest.WebServices.Plant
{
    /// <summary>
    ///     Tests for <see cref="PlantService" /> class.
    /// </summary>
    [TestClass]
    public class PlantServiceTests
    {
        #region Members.

        /// <summary>
        ///     Alert service.
        /// </summary>
        private readonly PlantService _plantService;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public PlantServiceTests()
        {
            _plantService = new PlantService();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Test for the <see cref="PlantService.GetAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetTestAsync()
        {
            var result = await _plantService.GetAsync();
            Assert.IsNotNull(result, "The result is null.");
        }

        /// <summary>
        ///     Test for the <see cref="PlantService.GetDetailsAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task GetDetailsTestAsync()
        {
            var result = await _plantService.GetDetailsAsync(0);
            Assert.IsNotNull(result, "The result is null.");
        }

        /// <summary>
        ///     Test for the <see cref="PlantService.CreateAsync"/> method.
        /// </summary>
        [TestMethod]
        public async Task CreateTestAsync()
        {
            const string name = "My plant";
            const string deviceIdentifier = "ARD1";
            const int varietyIdentifier = 0;
            IList<string> photos = new[] {"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAkGBwgHBgkICAgKCgkLDhcPDg0NDhwUFREXIh4jIyEeICAlKjUtJScyKCAgLj8vMjc5PDw8JC1CRkE6RjU7PDn/2wBDAQoKCg4MDhsPDxs5JiAmOTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTk5OTn/wAARCAABAAEDASIAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAf/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFAEBAAAAAAAAAAAAAAAAAAAAAP/EABQRAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhEDEQA/ALiAD//Z"};

            await _plantService.CreateAsync(name, deviceIdentifier, varietyIdentifier, photos);
        }

        #endregion Methods.
    }
}
