using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.HabilityCommands;
using PDIProject.Domain.Commands.UserCommands;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.DTOs.UserDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAllByCompanyId(int companyId);
        void CreateUser(UserCommand user);
        UserDTO GetBydId(int id);
        void CreateAbility(AbilityCommand command);
        void AssignAbilityOnUser(AbilityUserCommand command);
    }
}
