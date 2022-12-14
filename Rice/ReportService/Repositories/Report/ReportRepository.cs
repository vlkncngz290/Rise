using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReportService.Context;
using ReportService.DTOs.Report;
using ReportService.Requests.Report;

namespace ReportService.Repositories.Report
{
    public class ReportRepository:IReportRepository
    {
        private readonly PostgresqlDbContext _context;
        private readonly IMapper _mapper;

        public ReportRepository(PostgresqlDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public ReportReadDto Create(ReportPostRequest reportPostRequest)
        {
            if(reportPostRequest==null)
                throw new ArgumentNullException(nameof(reportPostRequest));
            Models.Report report = new Models.Report();
            report.RequestDate=DateTime.UtcNow;
            report.Status = Models.Report.REPORT_STATUS.IN_PROGRESS;
            _context.Reports.Add(report);
            SaveChanges();
            return _mapper.Map<ReportReadDto>(report);

        }

        public ICollection<ReportReadDto> GetAllReports(ReportGetAllRequest reportGetAllRequest)
        {
            var reports = _context.Reports.AsQueryable();
            if (reportGetAllRequest.ReportStatus!=null)
            {
                reports=reports.Where(report => report.Status==reportGetAllRequest.ReportStatus);
            }

            foreach (string relation in reportGetAllRequest.Include)
            {
                reports = reports.Include(relation);
            }

            reportGetAllRequest.TotalRecords=reports.Count();
            var result=reports.OrderBy(r=>r.Id)
                .Skip(reportGetAllRequest.GetOffset())
                .Take(reportGetAllRequest.GetLimit())
                .ToList();
            return _mapper.Map<ICollection<ReportReadDto>>(result);
        }


        public Boolean UpdateStatus(Guid Id, Models.Report.REPORT_STATUS status)
        {
            var report = _context.Reports.FirstOrDefault(r => r.Id == Id);
            report.Status = status;
            _context.Entry(report).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        private Boolean SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
