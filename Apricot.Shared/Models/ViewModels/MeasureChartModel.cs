using Apricot.Shared.Models.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    /// </summary>
    public class MeasureChartModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Measures.
        /// </summary>
        private IList<MeasureServiceModel> _measures;

        /// <summary>
        ///     Measure name.
        /// </summary>
        private string _name;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Gets or set a command for OnLoaded event.
        /// </summary>
        /// <value>The command for OnLoaded event.</value>
        public ICommand OnLoadedCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets or sets a measures.
        /// </summary>
        /// <value>The measures.</value>
        public IList<MeasureServiceModel> Measures
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