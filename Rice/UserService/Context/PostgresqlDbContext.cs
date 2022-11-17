﻿using Microsoft.EntityFrameworkCore;

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
    }
}
