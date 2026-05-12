using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SIGAPrincipal.BDAcademico
{
    public class DataAcademicoFactory : IDesignTimeDbContextFactory<DataAcademico>
    {
        public DataAcademico CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataAcademico>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("BDAcademico"));
            return new DataAcademico(optionsBuilder.Options);
        }
    }
}