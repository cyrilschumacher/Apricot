using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Resources;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Apricot.WebServices.Models.Plant;
using Apricot.WebServices.Plant;

namespace Apricot.Tasks
{
    /// <summary>
    ///     Task for to verify if a plant needs to be watered.
    /// </summary>
    public sealed class WateringAlertBackgroundTask : IBackgroundTask
    {
        #region Constants.

        /// <summary>
        ///     Time limit (in seconds).
        /// </summary>
        private const int TimeLimit = (6*3600);

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     Alert service.
        /// </summary>
        private readonly AlertService _alertService;

        /// <summary>
        ///     Plant service.
        /// </summary>
        private readonly PlantService _plantService;

        /// <summary>
        ///     Resources.
        /// </summary>
        private readonly ResourceLoader _resources;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public WateringAlertBackgroundTask()
        {
            // Initializes members.
            _alertService = new AlertService();
            _plantService = new PlantService();
            _resources = ResourceLoader.GetForCurrentView("/Apricot.Tasks/Resources");
        }

        #endregion Constructors.

        #region Methods.

        #region Private methods.

        /// <summary>
        ///     Checks if an active plant exceeds a threshold.
        /// </summary>
        private async Task _CheckActivePlantAsync()
        {
            var activePlant = await _GetActivePlantsAsync();
            foreach (var plant in activePlant)
            {
                var timeRemaining = await _alertService.GetTimeRemainingAsync(plant.Identifier);
                if (_HasExceededThreshold((int) timeRemaining.LeftTime))
                {
                    var toastTemplate = _CreateToastTemplate(plant);
                    _SendToast(toastTemplate);
                }
            }
        }

        /// <summary>
        ///     Creates a toast template by a plant informations.
        /// </summary>
        /// <param name="plant">The plant informations.</param>
        /// <returns>The toast template in XML format.</returns>
        private XmlDocument _CreateToastTemplate(PlantServiceModel plant)
        {
            const ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            var template = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var textElements = template.GetElementsByTagName("text");

            // Title.
            var title = _resources.GetString("NeedWatering");
            textElements[0].AppendChild(template.CreateTextNode(title));
            // Description.
            var description = _resources.GetString("NeedWatered");
            description = string.Format(description, plant.Name);
            textElements[1].AppendChild(template.CreateTextNode(description));

            return template;
        }

        /// <summary>
        ///     Gets active plants.
        /// </summary>
        /// <returns>The active plantes.</returns>
        private async Task<IEnumerable<PlantServiceModel>> _GetActivePlantsAsync()
        {
            var plants = await _plantService.GetAsync();
            return plants.Where(plant => plant.IsActive);
        }

        /// <summary>
        ///     Determines whether the threshold has been exceeded.
        /// </summary>
        /// <param name="leftTime">The left time.</param>
        /// <returns>True if the threshold has been exceeded, otherwise, False.</returns>
        private static bool _HasExceededThreshold(int leftTime)
        {
            var time = new TimeSpan(0, 0, leftTime);
            var timeLimit = new TimeSpan(0, 0, TimeLimit);

            return (time.CompareTo(timeLimit) < 0);
        }

        /// <summary>
        ///     Sends the Toast notification.
        /// </summary>
        private static void _SendToast(XmlDocument toastTemplate)
        {
            var notification = new ToastNotification(toastTemplate);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }

        #endregion Private methods.

        /// <summary>
        ///     Performs the work of a background task. The system calls this method when the associated background task has been
        ///     triggered.
        /// </summary>
        /// <param name="taskInstance">
        ///     An interface to an instance of the background task. The system creates this instance when the task has been
        ///     triggered to run.
        /// </param>
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            await _CheckActivePlantAsync();
            deferral.Complete();
        }

        #endregion Methods.
    }
}