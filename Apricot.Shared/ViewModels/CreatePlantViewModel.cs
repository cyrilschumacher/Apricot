using Apricot.Shared.Extensions;
using Apricot.Shared.Models;
using Apricot.Shared.Services.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.ComponentModel;
using System.Linq;
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

namespace Apricot.Shared.ViewModels
{
    /// <summary>
    ///     View model for the "create plant" view.
    /// </summary>
    [CLSCompliant(false)]
    public class CreatePlantViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        ///     Maximum number of photos allowed.
        /// </summary>
        private const int MaximumPhoto = 5;

        /// <summary>
        ///     Maximum width of the image.
        /// </summary>
        private const int MaximumWidthImage = 600;

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
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

        #endregion Members.

        #region Properties.

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

                // Initialize properties.
                Model = new CreatePlantModel
                {
                    CreateCommand = new RelayCommand(_CreateNewPlantAsync, _CreateNewPlantCanExecute),
                    OnLoadedCommand = new RelayCommand(_OnLoaded),
                    OnUnloadedCommand = new RelayCommand(_OnUnloaded),
                    AddPhotoCommand = new RelayCommand(_ShowPhotosSelector),
                    RemovePhotoCommand = new RelayCommand(_RemovePhoto)
                };
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
            Model.CreateCommand.RaiseCanExecuteChanged();
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
                // Obtains photo.
                foreach (var file in fileOpenPickerEventArgs.Files.Where(file => Model.Photos.Count < MaximumWidthImage))
                {
                    _AddPhotoAsync(file);
                }
            }
        }

        #endregion Events.

        /// <summary>
        ///     Adds a photo in the album.
        /// </summary>
        /// <param name="file">The file that represents the photo.</param>
        private async void _AddPhotoAsync(IStorageFile file)
        {
            var stream = await file.OpenAsync(FileAccessMode.Read);

            // Reduce photo size.
            var decoder = await BitmapDecoder.CreateAsync(stream);
            var inMemory = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateForTranscodingAsync(inMemory, decoder);
            encoder.BitmapTransform.ScaledWidth = MaximumWidthImage;

            // Write out to the stream.
            await encoder.FlushAsync();

            var photo = new BitmapImage();
            await photo.SetSourceAsync(stream);

            // Reset stream position for avoid a wrong Base64 data.
            stream.Seek(0);
            var base64Data = await stream.ToBase64();

            Model.Photos.Add(new PlantPhotoModel { Image = photo, Base64Data = base64Data });
        }

        /// <summary>
        ///     Creates a new plant by user informations.
        /// </summary>
        private async void _CreateNewPlantAsync()
        {
            // Obtains, only, the photos in Base64 format.
            var photos = Model.Photos.Select(p => p.Base64Data);

            try
            {
                // Create a new plant by user informations.
                await _plantService.CreateNewPlant(Model.Name, Model.SelectedVariety.Id, photos);
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
            return !string.IsNullOrEmpty(Model.Name) && (Model.SelectedVariety != null) &&
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
            var varieties = await _plantService.GetPlantVarieties();
            Model.Varieties.AddRange(varieties);
        }

        /// <summary>
        ///     Remove a photo.
        /// </summary>
        private void _RemovePhoto()
        {
            Model.Photos.RemoveAt(Model.SelectedPhotoIndex);
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
            filePicker.PickMultipleFilesAndContinue();
        }

        #endregion Methods.
    }
}