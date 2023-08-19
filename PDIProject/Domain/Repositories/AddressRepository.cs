using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PDIDataContext _context;
        public AddressRepository(PDIDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Adresses.Where(x => !x.Deleted).AsNoTracking();
        }

        public Address GetById(int id)
        {
            return _context.Adresses.FirstOrDefault(x => x.Id == id && !x.Deleted);
        }

        public void Add(Address address)
        {
            _context.Add(address);
        }
    }
}
