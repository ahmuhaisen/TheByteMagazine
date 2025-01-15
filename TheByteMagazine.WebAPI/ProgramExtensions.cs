using Microsoft.EntityFrameworkCore;
using TheByteMagazine.Domain.Entities;
using TheByteMagazine.Infrastructure.Data;
using TheByteMagazine.Application.Profiles;
using TheByteMagazine.Application.Services;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Repositories;
using Serilog;

namespace TheByteMagazine.WebAPI;

public static class ProgramExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSwaggerServices();
        services.AddCors(options => options
            .AddPolicy("AngularClient", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            })
        );

        services.AddCaching();

        services.AddUserIdentityWithEndpoints();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDatabaseContextWithLogging(configuration);
        return services;
    }

    private static void AddDatabaseContextWithLogging(this IServiceCollection services, IConfiguration configuration)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog()
            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
        });
    }

    private static void AddUserIdentityWithEndpoints(this IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIssuesRepository, IssuesRepository>();
        services.AddScoped<IContributionsRepository, ContributionsRepository>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        services.AddScoped<IMessagesRepository, MessagesRepository>();
        services.AddScoped<IArticlesRepository, ArticlesRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIssuesService, IssuesService>();
        services.AddScoped<IVolunteersService, VolunteersService>();
        services.AddScoped<IMessagesService, MessagesService>();
        services.AddScoped<IArticlesService, ArticlesServices>();
    }

    private static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
        });
    }

    private static void AddCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }
}
