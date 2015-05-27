using System;
using Apricot.Shared.Models.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for "plant information" page.
    /// </summary>
    [CLSCompliant(false)]
    public class PlantModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Details of the plant.
        /// </summary>
        private PlantDetailsModel _details;

        /// <summary>
        ///     Value that indicates if the plant is active or not.
        /// </summary>
        private bool _isActive;

        /// <summary>
        ///     Latest measure.
        /// </summary>
        private MeasureServiceModel _latestMeasure;

        /// <summary>
        ///     Measures.
        /// </summary>
        private List<MeasureServiceModel> _measures;

        /// <summary>
        ///     Plant name.
        /// </summary>
        private string _name;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Gets or sets a command for go to a measure chart page.
        /// </summary>
        /// <value>The command for see measure chart.</value>
        public RelayCommand<string> GoToChartPageCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for go to a variety information page.
        /// </summary>
        /// <value>The command for go to a variety information page.</value>
        public ICommand GoToVarietyInformationPageCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for <code>OnLoaded</code> event.
        /// </summary>
        /// <value>The command for <code>OnLoaded</code> event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or set a command for <code>OnUnloaded</code> event.
        /// </summary>
        /// <value>The command for <code>OnUnloaded</code> event.</value>
        public ICommand OnUnloadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for stop the measures of the plant.
        /// </summary>
        /// <value>The command forstop the measures of the plant.</value>
        public RelayCommand StopCommand { get; set; }

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
        ///     Gets or sets a value that indicates if the plant is active or not.
        /// </summary>
        /// <value>The value that indicates if the plant is active or not.</value>
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                SetValueProperty(ref _isActive, value);
            }
        }

        /// <summary>
        ///     Gets or sets a latest measure.
        /// </summary>
        /// <value>The latest measure.</value>
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
        ///     Gets or sets measures.
        /// </summary>
        /// <value>Measures.</value>
        public IList<MeasureServiceModel> Measures
        {
            get
            {
                return _measures;
            }
            set
            {
                //todo: To delete.
                var measures = value.Where(p => p != null).Take(50).ToList();
                SetValueProperty(ref _measures, measures);
            }
        }

        /// <summary>
        ///     Gets or set a plant name.
        /// </summary>
        /// <value>The plant name.</value>
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