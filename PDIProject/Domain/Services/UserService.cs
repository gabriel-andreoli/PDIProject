using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;

namespace PDIProject.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        public UserService(IUserRepository userRepository, ICompanyRepository companyRepository) 
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }
        public IEnumerable<User> GetAll() 
        { 
            return _userRepository.GetAll();
        }

        public User GetBydId(int id)
        {
            return _userRepository.GetById(id);
        }

        public void CreateUser(UserCommand user) 
        {
            var userNew = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            userNew.Company = _companyRepository.GetById(user.CompanyId);
            _userRepository.Add(userNew);
        }
    }
}
