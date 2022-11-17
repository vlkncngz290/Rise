using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Context
{
    public class PostgresqlDbContext:DbContext
    {
        public PostgresqlDbContext(DbContextOptions<PostgresqlDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
