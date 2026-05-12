using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SIGAPrincipal.BDAutenticacion
{
    public class DataAutenticacionFactory : IDesignTimeDbContextFactory<DataAutenticacion>
    {
        public DataAutenticacion CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataAutenticacion>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("BDAutenticacion"));
            return new DataAutenticacion(optionsBuilder.Options);
        }
    }
}
