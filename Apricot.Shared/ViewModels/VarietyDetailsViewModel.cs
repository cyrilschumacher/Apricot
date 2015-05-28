﻿using System.Windows.Input;
using Apricot.Shared.Models.ViewModels;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows information of variety of a plant.
    /// </summary>
    public class VarietyDetailsViewModel : ViewModelBase
    {
        #region Members.

        /// <summary>
        ///     Variety plant service.
        /// </summary>
        private readonly VarietyPlantService _varietyPlantService;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Get or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for OnLoaded event</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Get or sets a command for <code>OnUnloaded</code> event.
        /// </summary>
        /// <value>The command for OnUnloaded event</value>
        public ICommand OnUnloadedCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public VarietyDetailsModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public VarietyDetailsViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _varietyPlantService = new VarietyPlantService();

                // Initialize properties.
                Model = new VarietyDetailsModel();
                OnLoadedCommand = new RelayCommand(_OnLoaded);
                OnUnloadedCommand = new RelayCommand(_OnUnloaded);

                // Register messengers.
                MessengerInstance.Register<int>(this, _OnPlantIdentifierMessage);
            }
        }

        #endregion Constructors.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Occurs when the user presses the hardware Back button.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnHardwareButtonsOnBackPressed(object sender, BackPressedEventArgs e)
        {
            // Handles the back button for avoid a application suspension.
            e.Handled = true;

            // Navigates to the previous page if the root frame is obtained.
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                rootFrame.GoBack();
            }
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            // Initializes events.
            HardwareButtons.BackPressed += _OnHardwareButtonsOnBackPressed;
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            // Removes events.
            HardwareButtons.BackPressed -= _OnHardwareButtonsOnBackPressed;
        }

        /// <summary>
        ///     Receives the plant identifier.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        private void _OnPlantIdentifierMessage(int varietyIdentifier)
        {
            _LoadVarietyInformationAsync(varietyIdentifier);
        }

        #endregion Events.

        /// <summary>
        ///     Loads the variety information.
        /// </summary>
        /// <param name="varietyIdentifier">The variety identifier.</param>
        private async void _LoadVarietyInformationAsync(int varietyIdentifier)
        {
            Model.Details = await _varietyPlantService.GetVarietyDetails(varietyIdentifier);
        }

        #endregion Methods.
    }
}