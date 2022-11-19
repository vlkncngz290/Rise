using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Grpc.Net.Client;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportService.Models;
using ReportService.Repositories.Report;
using UserService.Protos;

namespace ReportService.AsyncDataService
{
    public class ReportRequestConsumerService:BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public ReportRequestConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
            _connectionFactory=new ConnectionFactory(){HostName = "localhost"};
            _connection=_connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("reports",durable:false,exclusive:false,autoDelete:false,arguments:null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();
                return Task.CompletedTask;
            }

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body= ea.Body.ToArray();
                var message=Encoding.UTF8.GetString(body);
                Task.Run(() =>
                {
                    ReportProduce? reportProduce = JsonSerializer.Deserialize<ReportProduce>(message);
                    Console.WriteLine(reportProduce.Location);
                    using (var scope=_serviceProvider.CreateScope())
                    {
                        var reportRepository = scope.ServiceProvider.GetRequiredService<IReportRepository>();
                        var channel = GrpcChannel.ForAddress("http://localhost:1000");
                        var client = new GrpcReports.GrpcReportsClient(channel);
                        GetReportRequest getReportRequest = new GetReportRequest();
                        getReportRequest.Location = reportProduce.Location;
                        var response = client.GetReport(getReportRequest);
                        reportRepository.UpdateStatus(reportProduce.ReportId);

                    }
                });
                
                

            };
            _channel.BasicConsume(queue: "reports", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
