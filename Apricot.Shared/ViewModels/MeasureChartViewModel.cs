﻿using Apricot.Shared.Models.Messages;
using Apricot.Shared.Models.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Apricot.Shared.Extensions;
using Apricot.WebServices.Models.Plant;
using Apricot.WebServices.Plant;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for shows measure chart.
    /// </summary>
    public class MeasureChartViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        ///     Duration before refreshing hours (to milliseconds).
        /// </summary>
        private const int RefreshingHoursDuration = 1000;

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

        #region Commands.

        /// <summary>
        ///     Gets or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for <code>OnLoaded</code> event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for <code>OnUnloaded</code> event.
        /// </summary>
        /// <value>The command for <code>OnUnloaded</code> event.</value>
        public ICommand OnUnloadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for refresh hours.
        /// </summary>
        /// <value>The command for refresh hours.</value>
        public ICommand RefreshHoursCommand { get; set; }

        #endregion Commands.

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
                _refreshTimer = new DispatcherTimer { Interval = new TimeSpan(TimeSpan.TicksPerMillisecond * RefreshingHoursDuration) };

                // Initialize properties.
                Model = new MeasureChartModel
                {
                    Hours = 1,
                    Measures = new List<MeasureServiceModel>(),
                    Name = "Humidity"
                };
                OnLoadedCommand = new RelayCommand(_OnLoaded);
                OnUnloadedCommand = new RelayCommand(_OnUnloaded);
                RefreshHoursCommand = new RelayCommand(_RefreshHours);

                // Register messengers.
                MessengerInstance.Register<MeasureMessageModel>(this, _OnMeasureServiceMessage);
            }
        }

        #endregion Constructors.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            // Initializes events.
            _refreshTimer.Tick += _OnRefreshTimerTick;

            // Unregister messengers.
            MessengerInstance.Unregister<MeasureMessageModel>(this, _OnMeasureServiceMessage);
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            // Initializes events.
            _refreshTimer.Tick -= _OnRefreshTimerTick;
        }

        /// <summary>
        ///     Receives the measures (with its name).
        /// </summary>
        /// <param name="message">The message.</param>
        private void _OnMeasureServiceMessage(MeasureMessageModel message)
        {
            // Obtains the plant identifiant and name.
            Model.Name = message.Name;
            _plantIdentifier = message.PlantIdentifier;

            // Load all measures.
            _LoadMeasuresAsync();
        }

        /// <summary>
        ///     Occurs when the timer interval has elapsed.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="o">The parameters.</param>
        private void _OnRefreshTimerTick(object sender, object o)
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
            Model.IsLoading = true;

            try
            {
                var measures = await _measureService.GetAll(_plantIdentifier, Model.Hours);

                // Create a counter and
                // and selects the requested property.
                var i = 0;
                Model.Measures = measures.Select(measure => new {X = i++, Y = measure.Measure.GetPropertyValue(Model.Name)});
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                Model.IsLoading = false;
            }
        }

        #endregion Methods.
    }
}