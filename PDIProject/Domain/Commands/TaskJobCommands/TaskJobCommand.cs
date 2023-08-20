using PDIProject.Domain.Enums;

namespace PDIProject.Domain.Commands.TaskJobCommands
{
    public class TaskJobCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpirationDate { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }
    }
}
