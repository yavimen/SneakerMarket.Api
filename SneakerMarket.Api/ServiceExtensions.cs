using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace SneakerMarket.Api
{
    static public class ServiceExtentions
    {
        static public void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        static public void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["connectionString"];

            services.AddDbContext<ApplicationContext>(o =>
                o.UseSqlServer(connectionString)
            );
        }

        static public void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
