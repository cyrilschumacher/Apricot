namespace Apricot.Shared.Model.Service
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
            Up,
            Down
        }

        /// <summary>
        ///     Gets or sets the status of health server.
        /// </summary>
        public HealthStatus Status { get; set; }
    }
}
