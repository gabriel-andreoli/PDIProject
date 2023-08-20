using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.HabilityCommands;
using PDIProject.Domain.Commands.UserCommands;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.ExtensionMethods;
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

        public void CreateHability(HabilityCommand command) 
        {
            var company = _companyRepository.GetById(command.CompanyId);
            if (company == null)
                throw new ArgumentNullException("Company não existente, verifique os dados e tente novamente");

            var hability = new Hability()
            { 
                Name= command.Name,
                Description= command.Description,
                CompanyId= command.CompanyId,
            };

            _userRepository.CreateHability(hability);
            Commit();
        }

        public void AssignHabilityOnUser(HabilityUserCommand command) 
        {
            //var user = _userRepository.GetById(command.UserId);
            var user = _userRepository.GetByIdWithHabilities(command.UserId);
            var hability = _userRepository.GetHabilityById(command.HabilityId);

            if (user == null)
                throw new ArgumentNullException("Usuário não encontrado");

            if (hability == null)
                throw new ArgumentNullException("Habilidade não encontrada");

            if (user.HabilitiesUser.Any(x => x.HabilityId == hability.Id))
                throw new Exception("Uma mesma habilidade não pode ser vinculada duas vezes para um mesmo usuário");

            var habilityUser = new HabilityUser()
            {
                User = user,
                Hability = hability,
                DateAcquisition = command.DateAcquisition.ToDateTime()
            };

            _userRepository.AssignHabilityOnUser(habilityUser);
            Commit();
        }
    }
}
