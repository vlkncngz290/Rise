using System.ComponentModel.DataAnnotations;
using UserService.Configuration;

namespace UserService.Requests.BaseRequest
{
    public class BaseRequest
    {
        [Range(1, 200)]
        public int PageSize { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultPageSize"]);

        public int PageNumber { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultPageNumber"]);

        public int TotalRecords { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultTotalRecords"]);

        public List<String> Include { get; set; } = new List<String>();

        public int GetOffset()
        {
            if (((PageNumber - 1) * PageSize) > 0)
                return (PageNumber - 1) * PageSize;
            return 0;
        }

        public int GetLimit()
        {
            return PageSize;
        }
    }
}
