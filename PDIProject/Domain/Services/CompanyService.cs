using PDIProject.Domain.Commands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressRepository _addressRepository;
        public CompanyService(IUnitOfWork unitOfWork, ICompanyRepository companyRepository, IAddressRepository addressRepository) : base(unitOfWork)
        { 
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
        }

        public IEnumerable<Company> GetAll() 
        {
            return _companyRepository.GetAll();
        }

        public Company GetById(int id) 
        {
            return _companyRepository.GetById(id);
        }

        public void CreateCompany(CompanyCommand command)
        {
            if (command.Address == null)
                throw new ArgumentException($"{nameof(command.Address)} is null");

            var newAddress = new Address()
            {
                Street = command.Address.Street,
                City = command.Address.City,
                PostalCode = command.Address.PostalCode,
                Country = command.Address.Country,
                Neighborhood = command.Address.Neighborhood,
                State = command.Address.State,
            };
            var newCompany = new Company()
            { 
                Name = command.Name,
                TotalEmployees = command.TotalEmployees,
                Email = command.Email,
                Address = newAddress
            };
            _addressRepository.Add(newAddress);
            _companyRepository.Add(newCompany);
            Commit();
        }
    }
}
