namespace SyncSoft.Olliix
{
    public class OlliixEngineOption
    {
        public string ResourceName { get; set; }
        public bool UseRabbitMQ { get; set; } = true;
        public bool AllowOverridingRegistrations { get; set; } = false;
    }
}
