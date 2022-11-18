using Microsoft.EntityFrameworkCore;
using ReportService.Models;

namespace ReportService.Context
{
    public class PostgresqlDbContext : DbContext
    {
        public PostgresqlDbContext(DbContextOptions<PostgresqlDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportContents> ReportContents { get; set; }
    }
}
