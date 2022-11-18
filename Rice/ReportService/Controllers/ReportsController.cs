using System.Diagnostics;
using System.Net;
using Confluent.Kafka;
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
        private readonly string bootstrapServers = "localhost:9092";
        private readonly string topic = "report";

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository=reportRepository;
        }

        [HttpPost]
        public async Task<ReportReadDto> Post([FromBody] ReportPostRequest reportPostRequest)
        {
            ReportReadDto result= _reportRepository.Create(reportPostRequest);
            await SendOrderRequest(reportPostRequest.Location);
            return result;
        }

        private async Task<bool> SendOrderRequest(string location)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder<Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync(topic, new Message<Null, string>
                    {
                        Value = location
                    });
                    
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(false);
        }
    }
}

