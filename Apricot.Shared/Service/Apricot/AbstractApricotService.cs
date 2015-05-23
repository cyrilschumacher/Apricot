using Apricot.Shared.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
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
            _httpClient.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(DateTime.UtcNow);

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
        private static TModel _JsonResponseToObject<TModel>(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                throw new ArgumentNullException("jsonData", "The parameter is null or empty.");
            }
            if (!jsonData.IsJsonValue())
            {
                throw new ArgumentException("The data isn't a JSON data valid.", "jsonData");
            }

            return JsonConvert.DeserializeObject<TModel>(jsonData);
        }

        /// <summary>
        ///     Reads the content of <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="httpResponse">The HTTP response message.</param>
        /// <returns>The model.</returns>
        private static async Task<TModel> _ReadContentHttpResponse<TModel>(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("The HTTP request has failed.");
            }

            // Reads the HTTP request response and converts into a model.
            var response = await httpResponse.Content.ReadAsStringAsync();
            return _JsonResponseToObject<TModel>(response);
        }

        /// <summary>
        ///     Obtains a response of a service.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="serviceUri">The service Uri.</param>
        /// <param name="cancellationToken">The token for the cancellation request.</param>
        /// <returns>The response of service.</returns>
        protected async Task<TModel> Get<TModel>(string serviceUri, CancellationToken? cancellationToken = null)
        {
            // Creates a token if no token hasn't been defined.
            cancellationToken = cancellationToken ?? new CancellationToken();

            // Obtains the absolute URL (with the URI address of service) and sends a HTTP request.
            var requestUri = _GetServerAddress(serviceUri);
            var response = await _httpClient.GetAsync(requestUri, cancellationToken.Value);

            return await _ReadContentHttpResponse<TModel>(response);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="serviceUri">The service Uri.</param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken">The token for the cancellation request.</param>
        /// <returns>The response of service.</returns>
        protected async Task<TModel> Post<TModel>(string serviceUri, IDictionary<string, string> parameters, CancellationToken? cancellationToken = null)
        {
            // Creates a token if no token hasn't been defined.
            cancellationToken = cancellationToken ?? new CancellationToken();

            // Obtains the absolute URL (with the URI address of service),
            // adds content and sends a HTTP request.
            var requestUri = _GetServerAddress(serviceUri);
            var content = new FormUrlEncodedContent(parameters);
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken.Value);

            return await _ReadContentHttpResponse<TModel>(response);
        }

        #endregion Methods.
    }
}