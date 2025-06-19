using ForkliftDirectory.Application.Interfaces;
using ForkliftDirectory.Infrastructure.Persistence;
using ForkliftDirectory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ForkliftDirectory.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IForkliftRepository, ForkliftRepository>();
            services.AddScoped<IForkliftDowntimeRepository, ForkliftDowntimeRepository>();

            return services;
        }
    }
}
