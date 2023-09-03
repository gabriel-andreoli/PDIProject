using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }
        public List<string> Abilities { get; set; }
        public string JobPosition { get; set; }
        public UserDTO() 
        {
            Abilities = new List<string>();
        }
    }
}
