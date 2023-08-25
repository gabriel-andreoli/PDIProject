using PDIProject.Domain.Enums;

namespace PDIProject.Domain.Entities
{
    public class Requirement : BaseClass
    {
        public TaskJob TaskJob { get; set; }
        public int TaskJobId { get; set; }
        public Ability Ability { get; set; }
        public int AbilityId { get; set; }
        public ERequirementPriority Priority {get; set;}
        public Requirement() { }
    }
}
