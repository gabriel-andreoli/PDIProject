using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Commands.UserCommands
{
    public class UserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }
        public int JobPositionId { get; set; }
    }
}
