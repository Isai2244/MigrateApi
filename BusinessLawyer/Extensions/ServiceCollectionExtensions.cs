using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataAccessLawyer.Extensions;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Implementation;

namespace MigrateMap.Bal.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddItemServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMapperBal, MapperBal>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICorporationService, CorporationService>();
            services.AddScoped<IMappingDBService, MappingDBService>();
            services.AddScoped<IUploadMapDocService, UploadMapDocService>();
            services.AddDBItemServices(configuration);
            return services;
        }
    }
}
