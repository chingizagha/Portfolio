namespace PortfolioMVC.Models
{
    public class Career
    {
        public int CareerId { get; set; }
        public string? Name { get; set; }
        public string? ShortDesc { get; set; }
        public string? LongDesc { get; set; }
        public string? Location { get; set; }
        public string? Link { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
