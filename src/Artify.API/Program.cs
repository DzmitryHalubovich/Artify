using Artify.API.Extensions;
using Artify.API.Filters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using Serilog;

Log.Logger = new LoggerConfiguration() //#1
    .WriteTo.Console().CreateLogger(); //#1

Log.Information("Starting up");//#1

try
{
    var builder = WebApplication.CreateBuilder(args);

    //Serilog #1
    builder.Host.UseSerilog((ctx, lc) => lc
           .WriteTo.Console()
           .WriteTo.Seq("http://localhost:5341")
           .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.ConfigureCors();
    builder.Services.ConfigureIISIntegration();
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureServiceManager();
    builder.Services.ConfigureSqlContext(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddScoped<ValidationFilterAttribute>();

    builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
    }).AddXmlDataContractSerializerFormatters()
        .AddCustomCSVFormatter()
        .AddApplicationPart(typeof(Artify.Presentation.AssemblyReference).Assembly);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    app.UseSerilogRequestLogging(configure =>
    {
        configure.MessageTemplate = "HTTPS {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
    });

    var logger = app.Services.GetRequiredService<Serilog.ILogger>();
    app.ConfigureExceptionHandler(logger);

    if (app.Environment.IsProduction())
    {
        app.UseHsts();
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"artworks-collection")),
        RequestPath = new PathString("/artworks-collection")
    });

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });
    app.UseCors("CorsPolicy");
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("HostAbortedException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

public partial class Program { }