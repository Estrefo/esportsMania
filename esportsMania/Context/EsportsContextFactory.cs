using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace esportsMania.Context
{
    public class EsportsContextFactory : IDesignTimeDbContextFactory<EsportsContext>
    {
        public EsportsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EsportsContext>();
            optionsBuilder.UseSqlServer("Server=PCESTREFO\\TEST;Database=esportsMania;Trusted_Connection=True;TrustServerCertificate=True;");

            return new EsportsContext(optionsBuilder.Options);
        }
    }
}
