using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.HabilityCommands;
using PDIProject.Domain.Commands.UserCommands;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void CreateUser(UserCommand user);
        User GetBydId(int id);
        void CreateHability(HabilityCommand command);
        void AssignHabilityOnUser(HabilityUserCommand command);
    }
}
