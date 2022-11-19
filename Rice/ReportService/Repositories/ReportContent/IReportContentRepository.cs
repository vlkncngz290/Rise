using ReportService.DTOs.ReportContent;

namespace ReportService.Repositories.ReportContents
{
    public interface IReportContentRepository
    {
        public Boolean Create(ReportContentPostDto reportContentPostDto);
    }
}
