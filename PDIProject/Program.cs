using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;
using PDIProject.Domain.Services;
using PDIProject.Persistence;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = $"Host={Environment.GetEnvironmentVariable("HOST")};" +
//                           $"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
//                           $"Username={Environment.GetEnvironmentVariable("USERNAME")};" +
//                           $"Password={Environment.GetEnvironmentVariable("PASSWORD")}";

var connectionString = "Host=dpg-cjlt3s5k5scs73b7batg-a; Database=pdiproject; Username=gabrielandreoli; Password=83cDMdzpjw6ytBCfQWEYFyWLKzhNxo9m";

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("PDIcs");

builder.Services.AddDbContext<PDIDataContext>(o => o.UseNpgsql(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITaskJobService, TaskJobService>();
builder.Services.AddScoped<ITaskJobRepository, TaskJobRepository>();

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<IJobPositionService, JobPositionService>();
builder.Services.AddScoped<IJobPositionRepository, JobPositionRepository>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins($"http://{Environment.GetEnvironmentVariable("PCGAB")}").AllowAnyHeader().AllowAnyMethod();
        }
    )
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
