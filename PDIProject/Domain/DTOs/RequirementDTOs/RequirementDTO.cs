using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.Enums;

namespace PDIProject.Domain.DTOs.RequirementDTOs
{
    public class RequirementDTO
    {
        public string Name { get; set; }
        public ERequirementPriority Priority { get; set; }
    }
}
