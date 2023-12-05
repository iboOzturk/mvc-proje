using Microsoft.EntityFrameworkCore;

namespace BlogAppApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-D2RIL31;database=BlogAppApiDb;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Market> Market { get; set; }
    }
}
