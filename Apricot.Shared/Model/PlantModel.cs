using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.Model
{
    /// <summary>
    ///     Model for "plant information" page.
    /// </summary>
    public class PlantModel
    {
        #region Properties.

        /// <summary>
        ///     Gets or sets a command for OnLoaded event.
        /// </summary>
        /// <value>The command for OnLoaded event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for pin plant.
        /// </summary>
        public RelayCommand PinCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for unpin plant.
        /// </summary>
        public RelayCommand UnpinCommand { get; set; }

        #endregion Properties.
    }
}
