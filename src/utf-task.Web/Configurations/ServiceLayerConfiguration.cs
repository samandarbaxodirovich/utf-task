using utf_task.DataAccess.Interfaces.Common;
using utf_task.DataAccess.Repositories.Common;
using utf_task.Service.Interfaces.Common;
using utf_task.Service.Interfaces.Main;
using utf_task.Service.Interfaces.Security;
using utf_task.Service.Services;
using utf_task.Service.Services.Common;
using utf_task.Service.Services.Security;

namespace kudapoyti.Web.Configurations.LayerConfigurations
{
    public static class ServiceLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaginatorService, PaginatorService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
        }
    }
}
