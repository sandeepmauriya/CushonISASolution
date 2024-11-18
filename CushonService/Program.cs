using IvestmentsCoreApi;
using IvestmentsCoreApi.Query;
using MediatR; // Import MediatR
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models; // For Swagger configuration
using Microsoft.EntityFrameworkCore;
using IvestmentsCoreApi.Infra;
using Microsoft.EntityFrameworkCore.SqlServer;
using IvestmentsCoreApi.Service;
using InvestmentsCoreApi.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Add Controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Investments Core API", Version = "v1" });
});




// Add MediatR and register all handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetFundsQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InvestHandler).Assembly));
builder.Services.AddScoped<FundsService>();
builder.Services.AddScoped<InvestmentsService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:3000")  // React frontend URL
            .AllowAnyMethod()                     // Allow any HTTP methods (GET, POST, etc.)
            .AllowAnyHeader());                   // Allow any headers
});


// Replace 'LoginHandler' with any handler class in the project. This scans and registers all handlers in the assembly.

// Add DbContext with SQL Server
builder.Services.AddDbContext<InvestmentsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging());
// Add additional services (e.g., database, authentication, etc.)
// builder.Services.AddDbContext<MyDbContext>(options => 
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddAuthentication(); // Example for JWT

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investments Core API v1");
    });
}

app.UseHttpsRedirection();
// Apply CORS globally
app.UseCors("AllowFrontend");

app.UseAuthentication(); // Use authentication middleware if configured
app.UseAuthorization();

app.MapControllers();

app.Run();
