using Apricot.Shared.Models.Services;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    /// </summary>
    public class VarietyDetailsModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Variety details.
        /// </summary>
        private VarietyDetailsServiceModel _details;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a variety details.
        /// </summary>
        /// <value>The variety details.</value>
        public VarietyDetailsServiceModel Details
        {
            get
            {
                return _details;
            }
            set
            {
                SetValueProperty(ref _details, value);
            }
        }

        #endregion Properties.
    }
}
