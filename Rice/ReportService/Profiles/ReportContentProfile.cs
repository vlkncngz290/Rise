using AutoMapper;
using ReportService.DTOs.ReportContent;
using ReportService.Models;

namespace ReportService.Profiles
{
    public class ReportContentProfile:Profile
    {
        public ReportContentProfile()
        {
            CreateMap<ReportContentPostDto, ReportContent>();
            CreateMap<ReportContent, ReportContentReadDto>();
        }
    }
}
