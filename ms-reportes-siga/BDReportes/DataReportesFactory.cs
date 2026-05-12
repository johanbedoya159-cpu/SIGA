using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SIGAPrincipal.BDReportes
{
    public class DataReportesFactory : IDesignTimeDbContextFactory<DataReportes>
    {
        public DataReportes CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataReportes>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("BDReportes"));
            return new DataReportes(optionsBuilder.Options);
        }
    }
}