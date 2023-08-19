using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class HabilityExtension
    {
        public static HabilityDTO ToHabilityDTO(this Hability hability) 
        {
            return new HabilityDTO() 
            {
                Name = hability.Name,
                Description = hability.Description
            };
        }
    }
}
