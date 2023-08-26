using PDIProject.Domain.DTOs.RequirementDTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Enums.Extensions;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class RequirementExtension
    {
        public static RequirementDTO ToRequirementDTO(this Requirement requirement)
        {
            return new RequirementDTO()
            {
                Name = requirement.Ability.Name,
                Priority = requirement.Priority
            };
        }
    }
}
