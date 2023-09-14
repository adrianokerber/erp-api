using ErpApi.Infra.CrossCutting.Extensions;
using ErpApi.WebAPI.Extensions;
using Otimizador.Infra.CrossCutting;
using Serilog;

try
{
    var loggerConfiguration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(loggerConfiguration)
        .CreateLogger();

    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    
    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.RegisterServices();
    builder.Services.RegisterFilters();
    builder.Services.RegisterMapperProfiles();
    builder.Services.RegisterSqlServer(builder.Configuration);

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionMiddleware();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}