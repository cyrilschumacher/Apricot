using Apricot.Shared.Model;

namespace Apricot.Shared.SampleData
{
    /// <summary>
    ///     Fake ViewModel for Main view.
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
