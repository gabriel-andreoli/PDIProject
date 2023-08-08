using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public void Add(User user);
    }
}
