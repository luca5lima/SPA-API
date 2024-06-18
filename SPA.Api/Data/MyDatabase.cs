using Microsoft.EntityFrameworkCore;
using SPA.Api.Models;

namespace SPA.Api.Data
{
    public class MyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SPAdb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesa>(despesa =>
            {
                despesa.HasKey(x => x.Id);
                despesa.Property(d => d.Description).IsRequired();
                despesa.Property(d => d.Value).IsRequired();
            });
        }

        public DbSet<Despesa> Despesas { get; set; }

    }
}
