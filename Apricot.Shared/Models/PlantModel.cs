using System.Windows.Input;
using Apricot.Shared.Models.Services;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.Models
{
    /// <summary>
    ///     Model for "plant information" page.
    /// </summary>
    public class PlantModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Plant.
        /// </summary>
        private PlantServiceModel _plant;

        /// <summary>
        ///     Details of the plant.
        /// </summary>
        private PlantDetailsModel _details;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Gets or sets a command for OnLoaded event.
        /// </summary>
        /// <value>The command for OnLoaded event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or set a command for OnUnloaded event.
        /// </summary>
        /// <value>The command for OnUnloaded event.</value>
        public ICommand OnUnloadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for pin plant.
        /// </summary>
        /// <value>The command for pin plant.</value>
        public RelayCommand PinCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for unpin plant.
        /// </summary>
        /// <value>The command for unpin plant.</value>
        public RelayCommand UnpinCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets or sets a plant.
        /// </summary>
        /// <value>The plant.</value>
        public PlantServiceModel Plant
        {
            get
            {
                return _plant;
            }
            set
            {
                SetValueProperty(ref _plant, value);
            }
        }

        /// <summary>
        ///     Gets or sets a plant details.
        /// </summary>
        /// <value>The plant details.</value>
        public PlantDetailsModel Details
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

        public object T
        {
            
        }

        #endregion Properties.
    }
}
