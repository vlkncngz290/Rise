using ReportService.Requests.Base;

namespace ReportService.Requests.Report
{
    public class ReportGetAllRequest:BaseRequest
    {
        public Models.Report.REPORT_STATUS? ReportStatus { get; set; }
    }
}
