using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs.TeamDTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string DepartmentName { get; set; }
        public int TotalOfTaskJobsInTeam{ get; set; }
        public int TotalOfTaskJobsCompleted { get; set; }
        public int TotalOfTaskJobsPending { get; set; }
        public int TotalOfTaskJobsLate { get; set; }
        public List<TaskJobUserDTO> Users { get; set; }
    }
}
