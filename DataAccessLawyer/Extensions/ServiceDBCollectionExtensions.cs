using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace DataAccessLawyer.Extensions
{
    public static partial class ServiceDBCollectionExtensions
    {
        public static IServiceCollection AddDBItemServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICorpMappingDBRepository, CorpMappingDBRepository>();
            services.AddScoped<ICorporationRepository, CorporationRepository>();
            services.AddScoped<IMappingDBRepository, MappingDBRepository>();
            services.AddScoped<IUserCorpMappingDBRepository, UserCorpMappingDBRepository>();
            services.AddScoped<IUserCorporationRepository, UserCorporationRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IMapDocRepository, MapDocRepository>();
            services.AddDbContext<UserDBContext>(options => options.UseNpgsql(Configuration.GetRequiredSection("ConnectionString").Value.ToString()));
            return services;
        }
    }
}
