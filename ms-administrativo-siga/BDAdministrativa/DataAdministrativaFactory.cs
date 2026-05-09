using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SIGAPrincipal.BDAdministrativa
{
    public class DataAdministrativaFactory : IDesignTimeDbContextFactory<DataAdministrativa>
    {
        public DataAdministrativa CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataAdministrativa>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("BDAdministrativa"));
            return new DataAdministrativa(optionsBuilder.Options);
        }
    }
}
