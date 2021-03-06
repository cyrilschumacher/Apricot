﻿using Apricot.WebServices.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apricot.WebServices
{
    /// <summary>
    ///     Abstract Apricot Service.
    /// </summary>
    public abstract class AbstractApricotService
    {
        #region Constants.

        /// <summary>
        ///     Request timeout (in milliseconds).
        /// </summary>
        private const int DefaultTimeout = 3000;

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
        ///     JSON serializer settings.
        /// </summary>
        private readonly JsonSerializerSettings _jsonSerializerSettings;

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
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            _serverUriAddress = new Uri(ServerAddress, UriKind.Absolute);
        }

        #endregion Constructors.

        #region Methods.

        #region Private methods.

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
        private TModel _JsonResponseToObject<TModel>(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
            {
                throw new ArgumentNullException("jsonData", "The parameter is null or empty.");
            }
            if (!jsonData.IsValidJson())
            {
                throw new ArgumentException("The data isn't a JSON data valid.", "jsonData");
            }

            Debug.WriteLine("JSON received: {0}", jsonData);
            return JsonConvert.DeserializeObject<TModel>(jsonData, _jsonSerializerSettings);
        }

        /// <summary>
        ///     Reads the content of <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="httpResponse">The HTTP response message.</param>
        /// <returns>The model.</returns>
        private async Task<TModel> _ReadContentHttpResponse<TModel>(HttpResponseMessage httpResponse)
        {
            Debug.WriteLine("HTTP status: {0}", httpResponse.StatusCode);
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("The HTTP request has failed.");
            }

            // Reads the HTTP request response and converts into a model.
            var response = await httpResponse.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(response) ? default(TModel) : _JsonResponseToObject<TModel>(response);
        }

        #endregion Private methods.

        /// <summary>
        ///     Sends a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="serviceUri">The service Uri.</param>
        /// <param name="timeout">The request timeout.</param>
        /// <param name="cancellationToken">The token for the cancellation request.</param>
        /// <returns>The response of service.</returns>
        protected async Task GetAsync(string serviceUri, TimeSpan? timeout = null, CancellationToken? cancellationToken = null)
        {
            await GetAsync<Object>(serviceUri, timeout, cancellationToken);
        }

        /// <summary>
        ///     Sends a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="serviceUri">The service Uri.</param>
        /// <param name="timeout">The request timeout.</param>
        /// <param name="cancellationToken">The token for the cancellation request.</param>
        /// <returns>The response of service.</returns>
        protected async Task<TModel> GetAsync<TModel>(string serviceUri, TimeSpan? timeout = null, CancellationToken? cancellationToken = null)
        {
            // Creates a token if no token hasn't been defined.
            cancellationToken = cancellationToken ?? new CancellationToken();

            // Obtains the absolute URL (with the URI address of service) and sets the timeout.
            var requestUri = _GetServerAddress(serviceUri);
            timeout = timeout ?? TimeSpan.FromMilliseconds(DefaultTimeout);

            Debug.WriteLine("URI request: {0}", requestUri);
            Debug.WriteLine("Timeout: {0}", timeout);

            //  Sends a HTTP request and obtains the response.
            var response = await _httpClient.GetAsync(requestUri, cancellationToken.Value);
            return await _ReadContentHttpResponse<TModel>(response);
        }

        /// <summary>
        ///     Sends a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="serviceUri">The service Uri.</param>
        /// <param name="content">The content.</param>
        /// <param name="timeout">The request timeout.</param>
        /// <param name="cancellationToken">The token for the cancellation request.</param>
        /// <returns>The response of service.</returns>
        protected async Task PostAsync(string serviceUri, string content, TimeSpan? timeout = null, CancellationToken? cancellationToken = null)
        {
            // Creates a token if no token hasn't been defined.
            cancellationToken = cancellationToken ?? new CancellationToken();

            // Obtains the absolute URL (with the URI address of service),
            // adds content and sets the timeout.
            var requestUri = _GetServerAddress(serviceUri);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            timeout = timeout ?? TimeSpan.FromMilliseconds(DefaultTimeout);

            Debug.WriteLine("URI request: {0}", requestUri);
            Debug.WriteLine("Timeout: {0}", timeout);
            Debug.WriteLine("Content: {0}", content);

            // Sends a HTTP request.
            _httpClient.Timeout = timeout.Value;
            await _httpClient.PostAsync(requestUri, httpContent, cancellationToken.Value);
        }

        #endregion Methods.
    }
}