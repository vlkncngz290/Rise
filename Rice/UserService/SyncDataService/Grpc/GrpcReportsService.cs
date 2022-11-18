using Grpc.Core;
using UserService.Context;
using UserService.Models;
using UserService.Protos;

namespace UserService.SyncDataService.Grpc
{
    public class GrpcReportsService:GrpcReports.GrpcReportsBase
    {
        private readonly PostgresqlDbContext _postgresqlDbContext;

        public GrpcReportsService(PostgresqlDbContext postgresqlDbContext)
        {
            _postgresqlDbContext = postgresqlDbContext;
        }

        public Task<GrpcReportModel> GenerateReport(GetReportRequest request, ServerCallContext context)
        {
            var response=new GrpcReportModel();
            Contact c1=new Contact();
            var users = _postgresqlDbContext.Users
                .Where(u => u.Contacts.Any(c => c.DataType == Contact.CONTACT_TYPES.LOCATION))
                .Where(u => u.Contacts.Any(c => c.DataValue == request.Location))
                .AsQueryable();
            response.UserCount=users.Count();
            
            int phoneNumberCount=0;
            foreach (var user in users)
            {
                if (user.Contacts.Any(c=>c.DataType==Contact.CONTACT_TYPES.PHONE))
                {
                    phoneNumberCount++;
                }
            }
            response.PhoneNumberCount=phoneNumberCount;
            response.Location=request.Location;

            return Task.FromResult(response);
        }
    }
}
