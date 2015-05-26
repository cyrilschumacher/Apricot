using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Apricot.Shared.Models.Services;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.Models.ViewModels
{
    /// <summary>
    ///     Model for the "Create plant" view.
    /// </summary>
    [CLSCompliant(false)]
    public class CreatePlantModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Plant name.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Selected device.
        /// </summary>
        private DeviceModel _selectedDevice;

        /// <summary>
        ///     Selected variety.
        /// </summary>
        private VarietyPlantServiceModel _selectedVariety;

        /// <summary>
        ///     Selected photo index.
        /// </summary>
        private int _selectedPhotoIndex;

        #endregion Members.

        #region Properties.

        #region Commands.

        /// <summary>
        ///     Gets or sets a command for create a new plant.
        /// </summary>
        /// <value>The command for create a new plant.</value>
        public RelayCommand CreateCommand { get; set; }

        /// <summary>
        ///     Gets or sets a command for add a photo.
        /// </summary>
        /// <value>The command for add a photo.</value>
        public ICommand AddPhotoCommand { get; set; }

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
        ///     Gets or sets a command for remove a photo.
        /// </summary>
        /// <value>The command for remove a photo.</value>
        public ICommand RemovePhotoCommand { get; set; }

        #endregion Commands.

        /// <summary>
        ///     Gets or sets devices.
        /// </summary>
        public ObservableCollection<DeviceModel> Devices { get; set; }

        /// <summary>
        ///     Gets or sets a device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public DeviceModel SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                SetValueProperty(ref _selectedDevice, value);
            }
        }

        /// <summary>
        ///     Gets or sets a plant name.
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

        /// <summary>
        ///     Gets or sets a photos.
        /// </summary>
        /// <value>The photos.</value>
        public ObservableCollection<PlantPhotoModel> Photos { get; set; }

        /// <summary>
        ///     Gets or sets a plant varieties.
        /// </summary>
        /// <value>The plant varieties.</value>
        public ObservableCollection<VarietyPlantServiceModel> Varieties { get; set; }

        /// <summary>
        ///     Gets or sets a selected variety.
        /// </summary>
        /// <value>The selected variety.</value>
        public VarietyPlantServiceModel SelectedVariety
        {
            get
            {
                return _selectedVariety;
            }
            set
            {
                SetValueProperty(ref _selectedVariety, value);
            }
        }

        /// <summary>
        ///     Gets or sets a selected photo index.
        /// </summary>
        /// <value>The selected photo index.</value>
        public int SelectedPhotoIndex
        {
            get
            {
                return _selectedPhotoIndex;
            }
            set
            {
                SetValueProperty(ref _selectedPhotoIndex, value);
            }
        }

        #endregion Properties.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public CreatePlantModel()
        {
            Devices = new ObservableCollection<DeviceModel>
            {
                new DeviceModel {Identifier = "ARD1", Name = "Arduino 1"},
                new DeviceModel {Identifier = "ARD2", Name = "Arduino 2"},
            };
            Photos = new ObservableCollection<PlantPhotoModel>();
            SelectedPhotoIndex = -1;
            Varieties = new ObservableCollection<VarietyPlantServiceModel>();
        }

        #endregion Constructor.
    }
}