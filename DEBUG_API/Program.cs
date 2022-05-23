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

// Adding Cross Origin Resource sharing also known as CORS 
// This will allow restricted resources on a web page to be requested from another
// domain outside the domain from which the first resource was served.
builder.Services.AddCors();

// Build the application this step is done once the services for the application have been set.
// So don't move the line anywhere else.
var app = builder.Build();

// Temporarily allow the api to accept any kind of header attributes from the client.
// This will be updated in the near future once I understand what headers are and how to efficiently use them.
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4001")
        .WithMethods("GET")
        .WithHeaders("application/x-www-form-urlencoded");
    
    options.WithOrigins("http://localhost:3000")
        .WithMethods("GET")
        .WithHeaders("application/x-www-form-urlencoded");
});

// Create a service scope to get an ApplicationDbContext instance using DI.
using var serviceScope = ((IApplicationBuilder) app).ApplicationServices
    .GetRequiredService<IServiceScopeFactory>().CreateScope();

// Create a applicationDbContext instance.
var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

// Create a logger instance.
var logger = serviceScope.ServiceProvider.GetService<ILogger<Program>>();

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

// Create migration for the database if needed.
DebugApiMigration.Create(applicationDbContext, logger);

// Runs an application and block the calling thread until host shutdown.
app.Run();