namespace ReportService.Repositories.ReportProducer
{
    public interface IReportProducerRepository
    {
        void SendMessage<T>(T message);
    }
}
