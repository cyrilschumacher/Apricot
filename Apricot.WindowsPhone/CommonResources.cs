using Windows.ApplicationModel.Resources;

namespace Apricot
{
    public class CommonResources
    {
        private static ResourceLoader _resourceLoader;

        public static ResourceLoader Resources
        {
            get
            {
                _resourceLoader = _resourceLoader ?? ResourceLoader.GetForCurrentView();
                return _resourceLoader;
            }
        }

        ///<summary>
        ///     Gets a "_Humidity" value.
        ///</summary>
        /// <value>The "_Humidity" value.</value>
        public string Humidity
        {
            get { return Resources.GetString("_Humidity"); }
        }

        ///<summary>
        ///     Gets a "_Luminosity" value.
        ///</summary>
        /// <value>The "_Luminosity" value.</value>
        public string Luminosity
        {
            get { return Resources.GetString("_Luminosity"); }
        }

        ///<summary>
        ///     Gets a "_Temperature" value.
        ///</summary>
        /// <value>The "_Temperature" value.</value>
        public string Temperature
        {
            get { return Resources.GetString("_Temperature"); }
        }
    }
}
