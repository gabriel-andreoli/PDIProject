using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Add(User user);
        List<User> GetAllByTeamId(int teamId);
        User GetById(int id);
        User GetJobPositionByUserId(int userId);
        //TaskJobs
        User GetByIdWithTaskJob(int userId);
        //Habilities
        void CreateAbility(Ability Ability);
        Ability GetAbilityById(int abilityId);
        void AssignAbilityOnUser(AbilityUser abilityUser);
        User GetByIdWithAbilities(int userId);
    }
}
