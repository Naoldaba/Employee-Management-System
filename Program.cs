using DotNetEnv;
using EmployeeMgtAPI.Data;
using EmployeeMgtAPI.Repositories.Implementations;
using EmployeeMgtAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Load strings variables from the.env
string dbString = Env.GetString("DB_CONNECTION_STRING");
string secretKey = Env.GetString("SECRET_KEY");

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee Management System", Version = "v1" });
    c.EnableAnnotations();
});

// Configure Entity Framework with PostgreSQL
builder.Services.AddDbContext<ApplicationDbCtx>(options =>
    options.UseNpgsql(dbString));

// Register the Employee Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
