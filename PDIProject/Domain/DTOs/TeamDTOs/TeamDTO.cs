using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs.TeamDTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string DepartmentName { get; set; }
        public List<TaskJobUserDTO> Users { get; set; }
    }
}
