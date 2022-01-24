using DEBUG_COPPO_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add swagger openApi.
builder.Services.AddSwaggerGen();

// Add connection to the database.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the application this step is done once the services for the application have been set.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middleware for redirecting HTTP Requests to HTTPS.
app.UseHttpsRedirection();

// Add middleware that will enable authentication.
app.UseAuthorization();

// Add end points for controller actions.
app.MapControllers();

// Runs an application and block the calling thread until host shutdown.
app.Run();