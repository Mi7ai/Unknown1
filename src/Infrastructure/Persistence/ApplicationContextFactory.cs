using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
    {
        public ApplicationDataContext CreateDbContext(string[] args)
        {
            // Get the API project path
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDataContext(optionsBuilder.Options);
        }
    }
}