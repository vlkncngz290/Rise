using System.ComponentModel.DataAnnotations;

namespace ReportService.Requests.Report
{
    public class ReportPostRequest
    {
        [Required]
        public string Location { get; set; }
    }
}
