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

        public DbSet<Despesa> Despesas { get; set; }
    }
}
