using System;
using System.Collections.ObjectModel;
using Apricot.WebServices.Models.Plant;

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
        ///     Photo.
        /// </summary>
        private PlantPhotoModel _photo;

        /// <summary>
        ///     Selected device.
        /// </summary>
        private DeviceModel _selectedDevice;

        /// <summary>
        ///     Selected variety.
        /// </summary>
        private VarietiesServiceModel _selectedVariety;

        #endregion Members.

        #region Properties.

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
        ///     Gets or sets a photo.
        /// </summary>
        /// <value>The photo.</value>
        public PlantPhotoModel Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                SetValueProperty(ref _photo, value);
            }
        }

        /// <summary>
        ///     Gets or sets a plant varieties.
        /// </summary>
        /// <value>The plant varieties.</value>
        public ObservableCollection<VarietiesServiceModel> Varieties { get; set; }

        /// <summary>
        ///     Gets or sets a selected variety.
        /// </summary>
        /// <value>The selected variety.</value>
        public VarietiesServiceModel SelectedVariety
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
            Photo = new PlantPhotoModel();
            Varieties = new ObservableCollection<VarietiesServiceModel>();
        }

        #endregion Constructor.
    }
}