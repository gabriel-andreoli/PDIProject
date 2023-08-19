using PDIProject.Domain.Commands.JobPositionCommands;
using PDIProject.Domain.Commands.TeamCommands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class TeamService : ServiceBase, ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public TeamService(IUnitOfWork unitOfWork, ITeamRepository teamRepository, IDepartmentRepository departmentRepository) : base(unitOfWork)
        {
            _teamRepository = teamRepository;
            _departmentRepository = departmentRepository;
        }
        public void CreateTeam(TeamCommand command)
        {
            var department = _departmentRepository.GetById(command.DepartmentId);

            if(department == null)
                throw new ArgumentNullException($"{nameof(department)} is null");

            var newTeam = new Team() 
            {
                Name = command.Name,
                Department = department
            };
            _teamRepository.Add(newTeam);
            Commit();
        }
    }
}
