using AutoMapper;
using ReportService.Context;
using ReportService.DTOs.ReportContent;
using ReportService.Repositories.ReportContents;

namespace ReportService.Repositories.ReportContent
{
    public class ReportContentRepository:IReportContentRepository
    {
        private readonly PostgresqlDbContext _context;
        private readonly IMapper _mapper;

        public ReportContentRepository(PostgresqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Create(ReportContentPostDto reportContentPostDto)
        {
            if (reportContentPostDto==null)
            {
                return false;
            }
            Models.ReportContent reportContent=_mapper.Map<Models.ReportContent>(reportContentPostDto);
            _context.ReportContents.Add(reportContent);
            SaveChanges();
            return true;
        }

        private Boolean SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
