using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Commands
{
    public class CompanyCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalEmployees { get; set; }
    }
}
