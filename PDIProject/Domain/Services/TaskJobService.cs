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

            var taskJobUsersList = new List<TaskJobUser>();
            foreach (var userId in command.UserIds)
            { 
                var user = _userRepository.GetById(userId);
                if (user == null)
                    throw new ArgumentNullException("Verifique os dados e tente novamente.");

                if (user.TeamId != team.Id)
                    throw new ArgumentException("Algo está errado, contate o nosso suporte.");

                var taskJobUser = new TaskJobUser()
                { 
                    TaskJob = newTaskJob,
                    User = user,
                    AssignmentDate = command.AssignmentDate.ToDateTime(),
                };

                taskJobUsersList.Add(taskJobUser);
                _taskJobRepository.AddTaskJobUser(taskJobUser);
            }
            newTaskJob.TaskJobUsers = taskJobUsersList;
            _taskJobRepository.Add(newTaskJob);
            Commit();
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
                foreach (var user in team.Users)
                {
                    user.JobPosition = _userRepository.GetJobPositionByUserId(user.Id).JobPosition;
                    var userDTO = user.ToTaskJobUserDTO();
                    foreach (var hability in user.HabilitiesUser.Where(x => x.UserId == user.Id).ToList()) 
                    {
                        var habilityDTO = hability.Hability.ToHabilityDTO();
                        userDTO.Habilities.Add(habilityDTO);
                    }

                    foreach (var taskJobUser in user.TaskJobUsers.Where(x => x.UserId == user.Id).ToList())
                    {
                        var taskJobDTO = taskJobUser.TaskJob.ToTaskJobMinimalDTO();
                        userDTO.TaskJobs.Add(taskJobDTO);
                    }
                    taskJobUsers.Add(userDTO);
                }
                var teamDTO = team.ToTeamDTO();
                teamsDTO.Add(teamDTO);
                teamDTO.Users = taskJobUsers;
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
