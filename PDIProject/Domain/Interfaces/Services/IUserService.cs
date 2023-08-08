using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void CreateUser(User user);
    }
}
