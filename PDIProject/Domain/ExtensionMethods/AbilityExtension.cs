using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class AbilityExtension
    {
        public static AbilityDTO ToAbilityDTO(this Ability ability) 
        {
            return new AbilityDTO() 
            {
                Name = ability.Name,
                Description = ability.Description
            };
        }
    }
}
