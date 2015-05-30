using Apricot.Shared.Extensions;
using Apricot.Shared.Models;
using Apricot.Shared.Models.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Imaging;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Apricot.WebServices.Plant;

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for the creation of a plant.
    /// </summary>
    [CLSCompliant(false)]
    public class CreatePlantViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        ///     Maximum width of the image.
        /// </summary>
        private const int MaximumWidthImage = 200;

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     Application windows (with its thread).
        /// </summary>
        private readonly CoreApplicationView _coreApplicationView;

        /// <summary>
        ///     Navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        ///     Variety plant service.
        /// </summary>
        private readonly VarietyPlantService _varietyPlantService;

        /// <summary>
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

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
        ///     Gets the model.
        /// </summary>
        public CreatePlantModel Model { get; private set; }

        #endregion Properties.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public CreatePlantViewModel(INavigationService navigationService)
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _coreApplicationView = CoreApplication.GetCurrentView();
                _navigationService = navigationService;
                _plantService = new PlantService();
                _varietyPlantService = new VarietyPlantService();

                // Initialize properties.
                Model = new CreatePlantModel();
                CreateCommand = new RelayCommand(_CreateNewPlantAsync, _CreateNewPlantCanExecute);
                OnLoadedCommand = new RelayCommand(_OnLoaded);
                OnUnloadedCommand = new RelayCommand(_OnUnloaded);
                AddPhotoCommand = new RelayCommand(_ShowPhotosSelector);
                RemovePhotoCommand = new RelayCommand(_RemovePhoto);
            }
        }

        #endregion Constructor.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Occurs when the property of model has changed.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Test if the command of create a new plant is available.
            CreateCommand.RaiseCanExecuteChanged();
        }
        
        /// <summary>
        ///     Occurs when the user presses the hardware Back button.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnHardwareButtonsOnBackPressed(object sender, BackPressedEventArgs e)
        {
            // Handles the back button for avoid a application suspension.
            e.Handled = true;

            // Navigates to the previous page if the root frame is obtained.
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                rootFrame.GoBack();
            }
        }

        /// <summary>
        ///     Raises the Loaded event.
        /// </summary>
        private void _OnLoaded()
        {
            HardwareButtons.BackPressed += _OnHardwareButtonsOnBackPressed;
            Model.PropertyChanged += _OnPropertyChanged;

            _LoadPlantVarietiesAsync();
        }

        /// <summary>
        ///     Raises the Unloaded event.
        /// </summary>
        private void _OnUnloaded()
        {
            HardwareButtons.BackPressed -= _OnHardwareButtonsOnBackPressed;
            Model.PropertyChanged -= _OnPropertyChanged;
        }

        /// <summary>
        ///     Occurs when the view is activated.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnViewActivated(CoreApplicationView sender, IActivatedEventArgs e)
        {
            _coreApplicationView.Activated -= _OnViewActivated;

            // Obtains all files and
            // checks if, one at least file exists.
            var fileOpenPickerEventArgs = e as FileOpenPickerContinuationEventArgs;
            if ((fileOpenPickerEventArgs != null) && (fileOpenPickerEventArgs.Files.Count > 0))
            {
                // Obtains photo and adds its.
                var file = fileOpenPickerEventArgs.Files.First();
                _AddPhotoAsync(file);
            }
        }

        #endregion Events.

        /// <summary>
        ///     Adds a photo in the album.
        /// </summary>
        /// <param name="file">The file that represents the photo.</param>
        private async void _AddPhotoAsync(StorageFile file)
        {
            try
            {
                // Reads file.
                var stream = await file.OpenAsync(FileAccessMode.Read);

                // Gets the properties.
                var properties = await file.Properties.GetImagePropertiesAsync();
                var height = properties.Height;
                var width = properties.Width;

                // Reduce photo size.
                var decoder = await BitmapDecoder.CreateAsync(stream);
                var inMemory = new InMemoryRandomAccessStream();
                var encoder = await BitmapEncoder.CreateForTranscodingAsync(inMemory, decoder);
                encoder.BitmapTransform.ScaledWidth = MaximumWidthImage;
                encoder.BitmapTransform.ScaledHeight = (height*MaximumWidthImage)/width;

                // Write out to the stream.
                await encoder.FlushAsync();

                var photo = new BitmapImage();
                await photo.SetSourceAsync(inMemory);

                // Reset stream position for avoid a wrong Base64 data.
                inMemory.Seek(0);
                var base64Data = await inMemory.ToBase64();

                Model.Photo = new PlantPhotoModel {Image = photo, Base64Data = base64Data};
            }
            catch (Exception)
            {
                //todo: Manage errors.
            }
        }

        /// <summary>
        ///     Creates a new plant by user informations.
        /// </summary>
        private async void _CreateNewPlantAsync()
        {
            // Obtains, only, the photos in Base64 format.
            var photoList = new List<PlantPhotoModel> { Model.Photo };
            var photos = photoList.Select(photo => photo.Base64Data).ToList();

            try
            {
                // Create a new plant by user informations.
                await
                    _plantService.CreateAsync(Model.Name, Model.SelectedDevice.Identifier, Model.SelectedVariety.Identifier, photos);
                // Return to the previous page.
                _GoToPreviousPage();
            }
            catch (Exception)
            {
                //todo: Manage Exception.
            }
        }

        /// <summary>
        ///     Returns a value indicating whether the command to create a new plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        private bool _CreateNewPlantCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Model.Name) && (Model.SelectedVariety != null) &&
                   (Model.SelectedDevice != null);
        }

        /// <summary>
        ///     Go to previous page.
        /// </summary>
        private void _GoToPreviousPage()
        {
            _navigationService.GoBack();
        }

        /// <summary>
        ///     Loads the plant varieties.
        /// </summary>
        private async void _LoadPlantVarietiesAsync()
        {
            var varieties = await _varietyPlantService.GetAsync();
            Model.Varieties.AddRange(varieties);
        }

        /// <summary>
        ///     Remove a photo.
        /// </summary>
        private void _RemovePhoto()
        {
            Model.Photo = null;
        }

        /// <summary>
        ///     Show the photos selector.
        /// </summary>
        private void _ShowPhotosSelector()
        {
            _coreApplicationView.Activated += _OnViewActivated;

            var filePicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.PickSingleFileAndContinue();
        }

        #endregion Methods.
    }
}