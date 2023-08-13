using AutoMapper;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;

namespace PDIProject.Domain.Services
{
    public class TaskJobService : ITaskJobService
    {
        private readonly ITaskJobRepository _taskJobRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TaskJobService
            (
                ITaskJobRepository taskJobRepository,
                IUserRepository userRepository,
                IMapper mapper

            )
        {
            _taskJobRepository = taskJobRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public TaskJobUserDTO GetInfoAndTaskJobsByUserId(int userId) 
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                return null;
            var result = _mapper.Map<TaskJobUserDTO>(user);
            return result;
        }
    }
}
