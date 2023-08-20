using AutoMapper;
using PDIProject.Domain.Commands.TaskJobCommands;
using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.DTOs.TeamDTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Enums;
using PDIProject.Domain.ExtensionMethods;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class TaskJobService : ServiceBase, ITaskJobService
    {
        private readonly ITaskJobRepository _taskJobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IJobPositionRepository _jobPositionRepository;

        public TaskJobService
            (
                ITaskJobRepository taskJobRepository,
                IUserRepository userRepository,
                ITeamRepository teamRepository,
                ICompanyRepository companyRepository,
                IJobPositionRepository jobPositionRepository,
                IUnitOfWork unitOfWork
            ) : base(unitOfWork)
        {
            _taskJobRepository = taskJobRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _companyRepository = companyRepository;
            _jobPositionRepository = jobPositionRepository;
        }

        public void CreateTaskJob(TaskJobCommand command)
        {
            var team = _teamRepository.GetByTeamIdAndCompanyId(command.TeamId, command.CompanyId);
            var company = _companyRepository.GetById(command.CompanyId);

            if (team == null)
                throw new ArgumentNullException($"{nameof(team)} is null");

            if(company == null)
                throw new ArgumentNullException($"{nameof(company)} is null");

            
            var newTaskJob = new TaskJob() 
            {
                Name = command.Name,
                Description = command.Description,
                Company = company,
                TeamId = team.Id,
                Status = ETaskJobStatus.Pending,
                ExpirationDate = command.ExpirationDate.ToDateTime(),
            };

            _taskJobRepository.Add(newTaskJob);
            Commit();
        }

        public void AssignTaskJobOnUser(TaskJobUserCommand command) 
        {
            var taskJob = _taskJobRepository.GetById(command.TaskJobId);

            if (taskJob == null)
                throw new ArgumentNullException("Tarefa não encontrada, verifique os dados e tente novamente");

            foreach (var userId in command.UserIds)
            { 
                var user = _userRepository.GetByIdWithTaskJob(userId);

                if (user == null)
                    throw new ArgumentNullException("Usuário não encontrado");

                if (user.TaskJobUsers.Any(x => x.TaskJobId == taskJob.Id))
                    throw new Exception("Não é possível atribuir uma tarefa para um usuário que já está vinculado a esta tarefa.");

                var taskJobUser = new TaskJobUser()
                {
                    TaskJob = taskJob,
                    User = user,
                    AssignmentDate = command.AssignmentDate.HasValue ? command.AssignmentDate.Value.ToDateTime() : DateTime.Today
                };

                _taskJobRepository.AddTaskJobUser(taskJobUser);
                Commit();
            }

        }
        public TaskJobsByCompanyIdDTO GetByCompanyId(int companyId) 
        {
            List<TeamDTO> teamsDTO = new List<TeamDTO>(); 
            var teams = _teamRepository.GetAllByCompanyId(companyId).ToList();
            if (teams == null)
                throw new ArgumentNullException($"{nameof(Team)} não pode ser null");
            
            foreach (var team in teams)
            {
                List<TaskJobUserDTO> taskJobUsers = new List<TaskJobUserDTO>();
                var users = _userRepository.GetAllByTeamId(team.Id);
                foreach (var user in users)
                {
                    var userDTO = user.ToTaskJobUserDTO();
                    foreach (var habilityUser in user.HabilitiesUser) 
                    {
                        var habilityDTO = habilityUser.Hability.ToHabilityDTO();
                        userDTO.Habilities.Add(habilityDTO);
                    }

                    foreach (var taskJobUser in user.TaskJobUsers)
                    {
                        var taskJobDTO = taskJobUser.TaskJob.ToTaskJobMinimalDTO();
                        userDTO.TaskJobs.Add(taskJobDTO);
                    }
                    taskJobUsers.Add(userDTO);
                }
                var teamDTO = team.ToTeamDTO();
                teamDTO.Users = taskJobUsers;
                teamsDTO.Add(teamDTO);
            }

            var result = new TaskJobsByCompanyIdDTO()
            { 
                Teams = teamsDTO,
                CompanyId = companyId
            };
            return result;
        }
    }
}
