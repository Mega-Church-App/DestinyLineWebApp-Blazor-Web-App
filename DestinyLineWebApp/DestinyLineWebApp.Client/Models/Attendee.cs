namespace DestinyLineWebApp.Client.Models
{
    public class Attendee
    {
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public bool IsFirstTimer { get; set; }
    }
}
