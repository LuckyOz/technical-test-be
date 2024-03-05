namespace Apps.Configs
{
    public class AppConfig
    {
        public string? MariaDbConnectionString { get; set; }
        public int TotalShowPage { get; set; }
        public string? RabbiHost { get; set; }
        public string? RabbitQueue { get; set; }
    }
}
