using Microsoft.EntityFrameworkCore;
using ProfSystem.Data.Mappings;
using ProfSystem.Models;

namespace ProfSystem.Data
{
    public class ProfessionalDbContext : DbContext
    {
        public DbSet<Professional> Professionals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(@"Server = localhost, 1433; Database = ProfSystem; User ID = sa;
                                    Password = yourPassword; TrustServerCertificate = True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfiguration(new ProfessionalMapping());
    }
}