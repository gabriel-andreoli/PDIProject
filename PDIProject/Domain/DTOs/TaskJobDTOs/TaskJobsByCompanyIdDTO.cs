using PDIProject.Domain.DTOs.TeamDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs.TaskJobDTOs
{
    public class TaskJobsByCompanyIdDTO
    {
        public List<TeamDTO> Teams { get; set; }
        public int CompanyId { get; set; }
    }
}
