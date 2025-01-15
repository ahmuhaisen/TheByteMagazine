using OpenTelemetry.Logs;
using Serilog;
using TheByteMagazine.Domain.Entities;
using TheByteMagazine.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
                                               .CreateLogger();

builder.Host.UseSerilog();

builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter());

builder.Services.AddPresentationServices()
                .AddApplicationServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AngularClient");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapIdentityApi<ApplicationUser>();

app.MapControllers();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
