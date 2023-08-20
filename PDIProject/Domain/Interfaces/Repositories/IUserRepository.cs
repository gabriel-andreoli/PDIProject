using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Add(User user);
        User GetById(int id);
        User GetJobPositionByUserId(int userId);
    }
}
