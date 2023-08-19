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

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PDIcs");

builder.Services.AddDbContext<PDIDataContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskJobRepository, TaskJobRepository>();
builder.Services.AddScoped<ITaskJobService, TaskJobService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IJobPositionService, JobPositionService>();
builder.Services.AddScoped<IJobPositionRepository, JobPositionRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
