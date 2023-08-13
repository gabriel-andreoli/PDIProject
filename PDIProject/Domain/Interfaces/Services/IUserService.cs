using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void CreateUser(User user);
        User GetBydId(int id);
    }
}
