namespace Apricot.Shared.Model.Service
{
    public class ServerHealthModel
    {
        public enum HealthStatus
        {
            Up,
            Down
        }

        public HealthStatus Status { get; set; }
    }
}
