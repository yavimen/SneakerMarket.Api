using SneakerMarket.Api;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            services.ConfigureSqlServerContext(builder.Configuration);

            services.ConfigureCorsPolicy();

            services.ConfigureRepositoryWrapper();

            services.AddAutoMapper(typeof(Program));

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}