using Microsoft.EntityFrameworkCore;
using CodeRumor.DataAccessLibrary.DbContext;
using CodeRumor.DataAccessLibrary.Repositories;
using COMMON.Models;
using DEBUG_API.Data;
using DEBUG_API.Repositories;
using DEBUG_API.Utilities.DbMigration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add logging to this file.
builder.Services.AddLogging();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add swagger openApi.
builder.Services.AddSwaggerGen();

// Add connection to the database.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register needed repository.
builder.Services.AddScoped(typeof(IBaseRepository<CoppoLog>), typeof(CoppoLogsRepository));

// Register needed applicationDbContext.
builder.Services.AddScoped(typeof(IGeneralDbContext), typeof(ApplicationDbContext));

// Register needed migration builder
builder.Services.AddScoped(typeof(ICreateMigration), typeof(CreateMigration));

// Build the application this step is done once the services for the application have been set.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middleware that will enable authentication.
app.UseAuthorization();

// Add end points for controller actions.
app.MapControllers();

// Create a service scope to get an ApplicationDbContext instance using DI.
using var serviceScope = ((IApplicationBuilder) app).ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            
// Create a context to access members in the database.
var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();


var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<Program>>();

try
{
    // Run database migration.
    if (applicationDbContext != null)
    {
        applicationDbContext.Database.Migrate();
    }
}
catch (Exception error)
{
    logger.LogError("{Message}", error.Message);
}

// Runs an application and block the calling thread until host shutdown.
app.Run();