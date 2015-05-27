using System.Windows.Input;
using Apricot.Shared.Models.Services;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    /// </summary>
    public class VarietyInformationModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Variety information.
        /// </summary>
        private VarietyDetailsServiceModel _information;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Get or sets a command for OnUnloaded event.
        /// </summary>
        /// <value>The command for OnUnloaded event</value>
        public ICommand OnUnloadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a variety information.
        /// </summary>
        /// <value>The variety information.</value>
        public VarietyDetailsServiceModel Information
        {
            get
            {
                return _information;
            }
            set
            {
                SetValueProperty(ref _information, value);
            }
        }

        #endregion Properties.
    }
}
