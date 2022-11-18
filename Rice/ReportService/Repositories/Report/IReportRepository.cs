using ReportService.DTOs.Report;
using ReportService.Requests.Report;

namespace ReportService.Repositories.Report
{
    public interface IReportRepository
    {
        public ReportReadDto Create(ReportPostRequest reportPostRequest);
    }
}
