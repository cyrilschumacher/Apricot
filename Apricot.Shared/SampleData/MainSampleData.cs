using Apricot.Shared.Models;
using Apricot.Shared.Models.ViewModels;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake view model for the "Main" view.
    /// </summary>
    public class MainSampleData
    {
        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public MainModel Model { get; private set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MainSampleData()
        {
            Model = new MainModel
            {
                RetryIsVisible = true
            };
        }

        #endregion Constructors.
    }
}
