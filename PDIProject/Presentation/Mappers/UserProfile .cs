using AutoMapper;
using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Presentation.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, TaskJobUserDTO>();
        }
    }
}
