namespace ReportService.Models
{
    public class ReportProduce
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }

        public ReportProduce(Guid reportId, string location)
        {
            ReportId = reportId;
            Location = location;
            
        }

        public ReportProduce()
        {
            
        }
    }

}
