using Api_Mine.Infrastructure.Interfaces;
using Api_Mine.Models.Data_Access;
using Api_Mine.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers()
            .AddNewtonsoftJson();

        builder.Services.AddDbContext<ApiContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IDatabaseService<DrillBlockDatabaseModel>, DrillBlockDataAccessService>();
        builder.Services.AddScoped<IDatabaseService<DrillBlockPointsDatabaseModel>, DrillBlockPointsDataAccessService>();
        builder.Services.AddScoped<IDatabaseService<HoleDatabaseModel>, HoleDataAccessService>();
        builder.Services.AddScoped<IDatabaseService<HolePointsDatabaseModel>, HolePointsDataAccessService>();

        builder.Services.AddScoped<MapService>(); 
        builder.Services.AddScoped<ErrorHandlingService>();

        builder.Services.AddScoped<DrillBlockService>();
        builder.Services.AddScoped<DrillBlockPointsService>();
        builder.Services.AddScoped<HoleService>();
        builder.Services.AddScoped<HolePointsService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connString = WebApplication.CreateBuilder()
            .Configuration.GetConnectionString("DefaultConnection");


        object value = services.AddDbContext<ApiContext>(
            options => options.UseNpgsql(connString));
    }
}