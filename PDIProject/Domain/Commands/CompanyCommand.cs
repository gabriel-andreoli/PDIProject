using PDIProject.Domain.DTOs.AddressDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Commands
{
    public class CompanyCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalEmployees { get; set; }
        public AddressDTO Address { get; set; }
    }
}
