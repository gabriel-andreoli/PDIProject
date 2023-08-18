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

builder.Services.AddDbContext<PDIDataContext>(o => o.UseInMemoryDatabase(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<PDIDataContext>();
//    var newCompany = new Company
//    {
//        Name = "ABC Inc.",
//        Email = "info@abc.com",
//        Phone = "123-456-7890",
//        TotalEmployees = 100
//    };

//    // Criar o endereço
//    var newAddress = new Address
//    {
//        Street = "123 Main St",
//        Neighborhood = "Downtown",
//        City = "Cityville",
//        State = "Stateland",
//        Country = "Countryland",
//        PostalCode = "12345"
//    };
//    newCompany.Address = newAddress;

//    var user = new User()
//    {
//        Name = "Gabriel Andreoli",
//        Email = "teste@gmail.com",
//        Password = "20919Teste",
//        Company = newCompany
//    };
//    dbContext.Companies.Add(newCompany);
//    dbContext.Users.Add(user);

//    // Popule o banco de dados conforme necessário
//    // Exemplo: dbContext.Companies.Add(new Company { ... });
//    //          dbContext.Users.Add(new User { ... });
//    dbContext.SaveChanges();
//}


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
