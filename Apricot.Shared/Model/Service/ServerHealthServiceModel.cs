namespace Apricot.Shared.Models.Service
{
    /// <summary>
    ///     Model for server health.
    /// </summary>
    public class ServerHealthModel
    {
        /// <summary>
        ///     Health server status.
        /// </summary>
        public enum HealthStatus
        {
            /// <summary>
            ///     Serveur is down.
            /// </summary>
            Down,

            /// <summary>
            ///     Server is up.
            /// </summary>
            Up
        }

        /// <summary>
        ///     Gets or sets a status of health server.
        /// </summary>
        /// <value>The status of health server.</value>
        public HealthStatus Status { get; set; }
    }
}
