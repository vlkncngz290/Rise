namespace ReportService.DTOs.ReportContent
{
    public class ReportContentPostDto
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public int? UserCount { get; set; }
        public int? PhoneNumberCount { get; set; }
    }
}
