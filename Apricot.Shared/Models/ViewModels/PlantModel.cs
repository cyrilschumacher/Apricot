using System.Windows.Input;
using Apricot.Shared.Models.Services;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for "plant information" page.
    /// </summary>
    public class PlantModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Details of the plant.
        /// </summary>
        private PlantDetailsModel _details;

        /// <summary>
        ///     Latest measure.
        /// </summary>
        private MeasureServiceModel _latestMeasure;

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

        /// <summary>
        ///     Gets or sets the plant identifier.
        /// </summary>
        /// <value>The plant identifier.</value>
        public int Identifier { get; set; }

        /// <summary>
        ///     Gets or sets the latest measure.
        /// </summary>
        public MeasureServiceModel LatestMeasure
        {
            get
            {
                return _latestMeasure;
            }
            set
            {
                SetValueProperty(ref _latestMeasure, value);
            }
        }

        /// <summary>
        ///     Gets or set the name.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties.

        #region Methods.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static explicit operator PlantModel(PlantServiceModel model)
        {
            return new PlantModel
            {
                Details = new PlantDetailsModel(), 
                Identifier = model.Identifier,
                Name = model.Name
            };
        }

        #endregion Methods.
    }
}
