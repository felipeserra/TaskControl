using Microsoft.EntityFrameworkCore;
using Task.Domain.Models.Entity;
using TaskControl.Infra.Data.DataContext.Mapping;
using TaskControl.Infra.Data.Util;

namespace TaskControl.Infra.Data.DataContext
{
    public class TaskControlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Configuration.GetDefaultConnectionString());
    }
}