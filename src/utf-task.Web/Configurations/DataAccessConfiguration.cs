using Microsoft.EntityFrameworkCore;
using utf_task.DataAccess.DbContexts;
using utf_task.DataAccess.Interfaces.Common;
using utf_task.DataAccess.Repositories.Common;

namespace kudapoyti.Web.Configurations.LayerConfigurations
{
    public static class DataAccessConfiguration
    {

        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
