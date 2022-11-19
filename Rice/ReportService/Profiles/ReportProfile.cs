using AutoMapper;
using ReportService.DTOs.Report;
using ReportService.Models;
using ReportService.Requests.Report;

namespace ReportService.Profiles
{
    public class ReportProfile:Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportReadDto, Report>();
            CreateMap<Report, ReportReadDto>();
            CreateMap<Report, ReportPostRequest>();
            CreateMap<ReportPostRequest, Report>();
        }
    }
}
