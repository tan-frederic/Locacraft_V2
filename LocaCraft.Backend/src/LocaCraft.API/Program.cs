using LocaCraft.Application;
using LocaCraft.Infrastructure;
using LocaCraft.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

namespace LocaCraft.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string corsAllowAllName = "corsAllowAll";

            var builder = WebApplication.CreateBuilder(args);
            

            // Configure the database connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsAllowAllName, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Add services and repositories dependency injection
            builder.Services.AddServices();
            builder.Services.AddRepositories();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApi();

            builder.Services.AddControllers();

            builder.Host.UseSerilog();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference("docs", options =>
                {
                    options.Title = "LocaCraft API | Documentation | V1";
                    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
                app.MapGet("/", () => Results.Redirect("/docs/v1")).ExcludeFromDescription();
                app.MapGet("/index.html", () => Results.Redirect("/docs/v1")).ExcludeFromDescription();
            }
            else
            {
                app.MapGet("/", () => "Hello World!");
            }

            app.UseSerilogRequestLogging();
            app.MapControllers();

            app.Run();
        }
    }
}
