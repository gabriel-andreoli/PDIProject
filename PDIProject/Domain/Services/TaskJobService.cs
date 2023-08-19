using AutoMapper;
using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.DTOs.TeamDTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.ExtensionMethods;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Domain.Repositories;

namespace PDIProject.Domain.Services
{
    public class TaskJobService : ITaskJobService
    {
        private readonly ITaskJobRepository _taskJobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public TaskJobService
            (
                ITaskJobRepository taskJobRepository,
                IUserRepository userRepository,
                ITeamRepository teamRepository,
                ICompanyRepository companyRepository

            )
        {
            _taskJobRepository = taskJobRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _companyRepository = companyRepository;
        }
        public TaskJobsByCompanyIdDTO GetByCompanyId(int companyId) 
        {
            List<TeamDTO> teamsDTO = new List<TeamDTO>(); 
            var teams = _teamRepository.GetAllByCompanyId(companyId);
            if (teams == null)
                throw new ArgumentNullException($"{nameof(Team)} não pode ser null");

            foreach (var team in teams)
            {
                List<TaskJobUserDTO> taskJobUsers = new List<TaskJobUserDTO>();
                foreach (var user in team.Users)
                {
                    var userDTO = user.ToTaskJobUserDTO();
                    foreach (var hability in user.Habilities) 
                    {
                        var habilityDTO = hability.ToHabilityDTO();
                        userDTO.Habilities.Add(habilityDTO);
                    }

                    foreach (var taskJob in user.TaskJobs)
                    {
                        var taskJobDTO = taskJob.ToTaskJobMinimalDTO();
                        userDTO.TaskJobs.Add(taskJobDTO);
                    }
                    taskJobUsers.Add(userDTO);
                }
                var teamDTO = team.ToTeamDTO();
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
