using Artify.Repositories.Contracts;
using Artify.Repository;
using Artify.Repository.Repositories;
using Artify.Services;
using Artify.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Artify.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
             services.Configure<IISOptions>(options =>
             {

             });

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
             builder.AddMvcOptions(config => config.OutputFormatters.Add(new
                CsvOutputFormatter()));

    }
}
