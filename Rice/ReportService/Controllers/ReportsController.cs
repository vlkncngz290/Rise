using System.Collections;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.DTOs.Report;
using ReportService.Models;
using ReportService.Repositories.Report;
using ReportService.Repositories.ReportProducer;
using ReportService.Requests.Report;
using ReportService.Responses;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportProducerRepository _reportProducerRepository;

        public ReportsController(IReportRepository reportRepository, IReportProducerRepository reportProducerRepository)
        {
            _reportRepository=reportRepository;
            _reportProducerRepository=reportProducerRepository;
        }

        [HttpPost]
        public async Task<ReportReadDto> Post([FromBody] ReportPostRequest reportPostRequest)
        {
            ReportReadDto result= _reportRepository.Create(reportPostRequest);
            ReportProduce message = new ReportProduce(result.Id, reportPostRequest.Location);
            _reportProducerRepository.SendMessage(message);
            return result;
        }

        [HttpGet]
        public BaseResponse<ReportReadDto> GetAll([FromBody] ReportGetAllRequest reportGetAllRequest)
        {
            ICollection<ReportReadDto> data=_reportRepository.GetAllReports(reportGetAllRequest);
            return new BaseResponse<ReportReadDto>(data.ToList(), reportGetAllRequest.PageNumber, reportGetAllRequest.PageSize,
                reportGetAllRequest.TotalRecords);
        }


    }
}

