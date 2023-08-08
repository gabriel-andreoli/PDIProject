using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;

namespace PDIProject.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll() 
        { 
            return _userRepository.GetAll();
        }
        public void CreateUser(User user) 
        { 
            _userRepository.Add(user);
        }
    }
}
