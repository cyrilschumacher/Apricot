using Windows.UI.Xaml.Navigation;

namespace Apricot.View
{
    /// <summary>
    ///     Main View.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
