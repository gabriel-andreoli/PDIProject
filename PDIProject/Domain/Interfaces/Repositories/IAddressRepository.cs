using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(int id);
        void Add(Address address);
    }
}
