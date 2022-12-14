using ReportService.DTOs.ReportContent;

namespace ReportService.DTOs.Report
{
    public class ReportReadDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public Models.Report.REPORT_STATUS Status { get; set; }

        public ICollection<ReportContentReadDto>? ReportContents { get; set; }
    }
}
