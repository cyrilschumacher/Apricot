using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for shows measure name and the measures.
    /// </summary>
    public class MeasureChartModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Measures.
        /// </summary>
        private IEnumerable<Object> _measures;

        /// <summary>
        ///     Measure name.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Hours.
        /// </summary>
        private int _hours;

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
        ///     Gets or sets a measures.
        /// </summary>
        /// <value>The measures.</value>
        public IEnumerable<Object> Measures
        {
            get
            {
                return _measures;
            }
            set
            {
                SetValueProperty(ref _measures, value);
            }
        }

        /// <summary>
        ///     Gets or set a measure name.
        /// </summary>
        /// <value>The measure name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetValueProperty(ref _name, value);
            }
        }

        /// <summary>
        ///     Gets or sets hours.
        /// </summary>
        /// <value>The hours.</value>
        public int Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                SetValueProperty(ref _hours, value);
            }
        }

        #endregion Properties.
    }
}