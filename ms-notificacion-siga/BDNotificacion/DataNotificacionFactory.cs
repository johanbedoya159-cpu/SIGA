using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SIGAPrincipal.BDNotificacion
{
    public class DataNotificacionFactory : IDesignTimeDbContextFactory<DataNotificacion>
    {
        public DataNotificacion CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataNotificacion>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("BDNotificacion"));
            return new DataNotificacion(optionsBuilder.Options);
        }
    }
}

