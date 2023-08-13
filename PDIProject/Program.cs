using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;
using PDIProject.Domain.Services;
using PDIProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PDIcs");

builder.Services.AddDbContext<PDIDataContext>(o => o.UseInMemoryDatabase(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


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
