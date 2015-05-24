using Apricot.Shared.ViewModel;
using Apricot.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Apricot
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region Properties.

        /// <summary>
        ///     Gets the main view model.
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        ///     Gets the new plant view model.
        /// </summary>
        public NewPlantViewModel NewPlant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewPlantViewModel>();
            }
        }

        /// <summary>
        ///     Gets the plant chooser view model.
        /// </summary>
        public PlantChooserViewModel PlantChooser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlantChooserViewModel>();
            }
        }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register(_InitializeNavigationService);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NewPlantViewModel>();
            SimpleIoc.Default.Register<PlantChooserViewModel>();
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Initialize navigation service.
        /// </summary>
        /// <returns>The navigation service initialized.</returns>
        private static INavigationService _InitializeNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("PlantChooser", typeof(PlantChooserPage));

            return navigationService;
        }

        /// <summary>
        ///     Clear the view models.
        /// </summary>
        public static void Cleanup()
        {
        }

        #endregion Methods.
    }
}