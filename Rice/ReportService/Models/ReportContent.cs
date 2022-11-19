using ReportService.Models.Base;

namespace ReportService.Models
{
    public class ReportContent:BaseModel
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public int UserCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
