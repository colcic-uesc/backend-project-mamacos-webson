using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UescColcicAPI.Services.BD;

namespace UescColcicAPI.Services;
public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UescColcicDBContext> (options => options.UseSqlite(connectionString));
        }
    }