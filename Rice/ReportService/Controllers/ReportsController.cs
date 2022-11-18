using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.DTOs.Report;
using ReportService.Repositories.Report;
using ReportService.Requests.Report;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository=reportRepository;
        }

        [HttpPost]
        public ReportReadDto Post([FromBody] ReportPostRequest reportPostRequest)
        {
            return _reportRepository.Create(reportPostRequest);
        }
    }
}
