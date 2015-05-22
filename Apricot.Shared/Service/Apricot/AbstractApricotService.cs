using Apricot.Shared.Extension;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Apricot.Shared.Service.Apricot
{
    /// <summary>
    ///     Abstract Apricot Service.
    /// </summary>
    public abstract class AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Server address.
        /// </summary>
        private const string ServerAddress = "http://private-04cb2-apricot2.apiary-mock.com/";

        #endregion Constants.

        #region Members.

        /// <summary>
        ///     HTTP client.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Absolute URI server address.
        /// </summary>
        private readonly Uri _serverUriAddress;

        #endregion Members.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        protected AbstractApricotService()
        {
            _httpClient = new HttpClient();
            _serverUriAddress = new Uri(ServerAddress, UriKind.Absolute);
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Gets a the server address.
        /// </summary>
        /// <param name="serviceUri">A service address.</param>
        /// <returns>The absolute URI address of service.</returns>
        private Uri _GetServerAddress(string serviceUri)
        {
            return new Uri(_serverUriAddress, serviceUri);
        }

        /// <summary>
        ///     Converts a JSON data response to object model.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="jsonData">The JSON data.</param>
        /// <returns>The model object.</returns>
        private static TModel JsonResponseToObject<TModel>(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                throw new ArgumentNullException("jsonData", "The parameter is null or empty.");
            }
            if (!jsonData.IsJsonValue())
            {
                throw new ArgumentException("The data isn't a JSON data valid.");
            }

            return JsonConvert.DeserializeObject<TModel>(jsonData);
        }

        /// <summary>
        ///     Obtains a response of a service.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="serviceUri">The service Uri.</param>
        /// <returns>The response of service.</returns>
        protected async Task<TModel> GetResponse<TModel>(string serviceUri)
        {
            var requestUri = _GetServerAddress(serviceUri);
            var response = await _httpClient.GetStringAsync(requestUri);

            return JsonResponseToObject<TModel>(response);
        }

        #endregion Methods.
    }
}