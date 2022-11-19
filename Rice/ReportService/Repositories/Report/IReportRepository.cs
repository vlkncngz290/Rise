using ReportService.DTOs.Report;
using ReportService.Requests.Report;

namespace ReportService.Repositories.Report
{
    public interface IReportRepository
    {
        public ReportReadDto Create(ReportPostRequest reportPostRequest);
        public ICollection<ReportReadDto> GetAllReports(ReportGetAllRequest reportGetAllRequest);
        public Boolean UpdateStatus(Guid Id, Models.Report.REPORT_STATUS status);
    }
}
