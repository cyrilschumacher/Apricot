using Apricot.Shared.ViewModels;
using Apricot.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;

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
        ///     Gets a view model for creates a new plant.
        /// </summary>
        /// <value>The view model.</value>
        public CreatePlantViewModel CreatePlant
        {
            get
            {
                var guid = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<CreatePlantViewModel>(guid);
            }
        }

        /// <summary>
        ///     Gets the main view model.
        /// </summary>
        /// <value>The view model.</value>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        ///     Gets a view model for shows a measure chart.
        /// </summary>
        public MeasureChartViewModel MeasureChart
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MeasureChartViewModel>();
            }
        }

        /// <summary>
        ///     Gets a view model for shows plant information.
        /// </summary>
        /// <value>The view model.</value>
        public PlantViewModel Plant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlantViewModel>();
            }
        }

        /// <summary>
        ///     Gets the view model for select a plant.
        /// </summary>
        /// <value>The view model.</value>
        public PlantChooserViewModel PlantChooser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlantChooserViewModel>();
            }
        }

        /// <summary>
        ///     Gets the view model for shows the variety information.
        /// </summary>
        /// <value>The view model.</value>
        public VarietyDetailsViewModel VarietyDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VarietyDetailsViewModel>();
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
            SimpleIoc.Default.Register<CreatePlantViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MeasureChartViewModel>();
            SimpleIoc.Default.Register<PlantViewModel>();
            SimpleIoc.Default.Register<PlantChooserViewModel>();
            SimpleIoc.Default.Register<VarietyDetailsViewModel>();
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
            navigationService.Configure("MeasureChart", typeof(MeasureChartPage));
            navigationService.Configure("Plant", typeof(PlantPage));
            navigationService.Configure("PlantChooser", typeof(PlantChooserPage));
            navigationService.Configure("VarietyDetails", typeof(VarietyDetailsPage));

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