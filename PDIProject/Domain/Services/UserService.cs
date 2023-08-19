using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.UserCommands;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IJobPositionRepository _jobPositionRepository;
        public UserService
            (
                IUnitOfWork unitOfWork,
                IUserRepository userRepository,
                ICompanyRepository companyRepository,
                ITeamRepository teamRepository,
                IJobPositionRepository jobPositionRepository
            ) : base(unitOfWork) 
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _teamRepository = teamRepository;
            _jobPositionRepository = jobPositionRepository;
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
            var company = _companyRepository.GetById(user.CompanyId);
            var team = _teamRepository.GetById(user.TeamId);
            var jobPosition = _jobPositionRepository.GetById(user.JobPositionId);

            if (company == null)
                throw new ArgumentException("Forneça um CompanyId válido");

            if(team == null)
                throw new ArgumentException("Forneça um TeamId válido");

            if (jobPosition == null)
                throw new ArgumentException("Forneça um JobPositionId válido");

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            var userNew = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = hashedPassword,
                Salt = salt,
                Company = company,
                Team = team,
                JobPosition = jobPosition
            };          

            _userRepository.Add(userNew);
            Commit();
        }
    }
}
