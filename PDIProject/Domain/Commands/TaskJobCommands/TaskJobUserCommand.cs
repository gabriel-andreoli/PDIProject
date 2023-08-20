namespace PDIProject.Domain.Commands.TaskJobCommands
{
    public class TaskJobUserCommand
    {
        public int TaskJobId { get; set; }
        public List<int> UserIds { get; set; }
        public int? AssignmentDate { get; set; }
    }
}
