﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Apricot.Shared.Models.Messages;
using Apricot.Shared.Models.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Apricot.Shared.Extensions;
using Apricot.Shared.Models.Services;
using Apricot.Shared.Services.Apricot;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows measure chart.
    /// </summary>
    public class MeasureChartViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        ///     Duration before refreshing hours.
        /// </summary>
        private const int RefreshingHoursDuration = 2;

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     Service for manage measure.
        /// </summary>
        private readonly MeasureService _measureService;

        /// <summary>
        ///     Plant identifier.
        /// </summary>
        private int _plantIdentifier;

        /// <summary>
        ///     Timer for hours refresh.
        /// </summary>
        private readonly DispatcherTimer _refreshTimer;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a model.
        /// </summary>
        /// <value>The model.</value>
        public MeasureChartModel Model { get; set; }

        #endregion Properties.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public MeasureChartViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _measureService = new MeasureService();
                _refreshTimer = new DispatcherTimer {Interval = new TimeSpan(TimeSpan.TicksPerSecond*RefreshingHoursDuration)};

                // Initialize properties.
                Model = new MeasureChartModel
                {
                    Hours = 1,
                    Measures = new List<MeasureServiceModel>(),
                    Name = "Humidity",
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    OnUnloadedCommand = new RelayCommand(_OnUnloaded),
                    RefreshHoursCommand = new RelayCommand(_RefreshHours)
                };

                // Register messengers.
                MessengerInstance.Register<MeasureMessageModel>(this, _OnMeasureServiceMessage);
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
            _refreshTimer.Tick += _RefreshTimerOnTick;

            // Unregister messengers.
            MessengerInstance.Unregister<MeasureMessageModel>(this, _OnMeasureServiceMessage);
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            // Initializes events.
            HardwareButtons.BackPressed -= _OnHardwareButtonsOnBackPressed;
            _refreshTimer.Tick -= _RefreshTimerOnTick;
        }

        /// <summary>
        ///     Receives the measures (with its name).
        /// </summary>
        /// <param name="message">The message.</param>
        private async void _OnMeasureServiceMessage(MeasureMessageModel message)
        {
            Model.Name = message.Name;

            _plantIdentifier = message.PlantIdentifier;

            await Task.Delay(2000);
            _LoadMeasuresAsync();
        }

        private void _RefreshTimerOnTick(object sender, object o)
        {
            _refreshTimer.Stop();
            _LoadMeasuresAsync();
        }

        #endregion Events.

        /// <summary>
        ///     Refresh hours.
        /// </summary>
        private void _RefreshHours()
        {
            // The timer stops and restarts.
            _refreshTimer.Stop();
            _refreshTimer.Start();
        }

        /// <summary>
        ///     Loads the measures.
        /// </summary>
        private async void _LoadMeasuresAsync()
        {
            var measures = await _measureService.GetAll(_plantIdentifier, Model.Hours);

            var i = 0;
            Model.Measures = measures.Select(measure => new {X = i++, Y = measure.Measure.GetPropertyValue(Model.Name)});
        }

        #endregion Methods.
    }
}