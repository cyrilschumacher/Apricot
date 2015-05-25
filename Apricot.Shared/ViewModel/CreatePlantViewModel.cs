using System;
using System.ComponentModel;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Apricot.Shared.Extension;
using Apricot.Shared.Model;
using Apricot.Shared.Service.Apricot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Apricot.Shared.ViewModel
{
    /// <summary>
    ///     View model for the "create plant" view.
    /// </summary>
    public class CreatePlantViewModel : ViewModelBase
    {
        #region Constants.

        /// <summary>
        ///     Maximum number of photos allowed.
        /// </summary>
        private const int MaxPhoto = 5;

        #endregion Constants.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public CreatePlantViewModel()
        {
            // Don't execute the following code in design mode.
            // This condition avoids this error: "Object reference not set to an instance of an object" during
            // the visualizing of the XAML code in the design mode.
            if (!IsInDesignMode)
            {
                // Initialize members.
                _coreApplicationView = CoreApplication.GetCurrentView();
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

        #region Properties.

        /// <summary>
        ///     Gets the model.
        /// </summary>
        public CreatePlantModel Model { get; private set; }

        #endregion Properties.

        #region Members.

        /// <summary>
        ///     Application windows (with its thread).
        /// </summary>
        private readonly CoreApplicationView _coreApplicationView;

        /// <summary>
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

        #endregion Members.

        #region Methods.

        #region Events.

        /// <summary>
        ///     Occurs when the property of model has changed.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The parameters.</param>
        private void _OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
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
                foreach (var file in fileOpenPickerEventArgs.Files.Where(file => Model.Photos.Count < MaxPhoto))
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
            var photo = new BitmapImage();
            await photo.SetSourceAsync(stream);

            // Reset stream position for avoid a wrong Base64 data.
            stream.Seek(0);
            var base64Data = await stream.ToBase64();

            Model.Photos.Add(new PlantPhotoModel {Image = photo, Base64Data = base64Data});
        }

        /// <summary>
        ///     Creates a new plant by user informations.
        /// </summary>
        public async void _CreateNewPlantAsync()
        {
            var photos = Model.Photos.Select(p => p.Base64Data);
            await _plantService.CreateNewPlant(Model.Name, Model.SelectedVariety.Id, photos);
        }

        /// <summary>
        ///     Returns a value indicating whether the command to create a new plant is available.
        /// </summary>
        /// <returns>True if the command is available, otherwise, False.</returns>
        public bool _CreateNewPlantCanExecute()
        {
            return !string.IsNullOrEmpty(Model.Name) && (Model.SelectedVariety != null) &&
                   (Model.SelectedDevice != null);
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
            filePicker.FileTypeFilter.Add(".gif");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.PickMultipleFilesAndContinue();
        }

        #endregion Methods.
    }
}