using System;
using System.Collections.Generic;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for shows measure name and the measures.
    /// </summary>
    public class MeasureChartModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Hours.
        /// </summary>
        private int _hours;

        /// <summary>
        ///    Value that indicates a loading.
        /// </summary>
        private bool _isLoading;

        /// <summary>
        ///     Measures.
        /// </summary>
        private IEnumerable<Object> _measures;

        /// <summary>
        ///     Measure name.
        /// </summary>
        private string _name;

        #endregion Members.

        #region Properties.

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

        /// <summary>
        ///     Gets or sets a value that indicates a loading.
        /// </summary>
        /// <value>Tthe value that indicates a loading.</value>
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetValueProperty(ref _isLoading, value);
            }
        }

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

        #endregion Properties.
    }
}