using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.DTOs.TeamDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class TeamExtension
    {
        public static TeamDTO ToTeamDTO(this Team team) 
        {
            return new TeamDTO()
            {
                Id = team.Id,
                TeamName = team.Name,
                DepartmentName = team.Department.Name,
                Users = new List<TaskJobUserDTO>()
            };
        }
    }
}
