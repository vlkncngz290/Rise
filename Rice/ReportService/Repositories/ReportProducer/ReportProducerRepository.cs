using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ReportService.Repositories.ReportProducer
{
    public class ReportProducerRepository:IReportProducerRepository
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection=factory.CreateConnection();
            using (var channel=connection.CreateModel())
            {
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange:"",routingKey:"reports", body:body);
            }
        }
    }
}
