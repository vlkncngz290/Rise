using ReportService.Models.Base;

namespace ReportService.Models
{
    public class Report:BaseModel
    {

        public enum REPORT_STATUS
        {
            IN_PROGRESS,
            COMPLETE,
            FAIL
        }

        public DateTime RequestDate { get; set; }
        public REPORT_STATUS Status { get; set; }  
    }
}
