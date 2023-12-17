using AutoMapper;
using TasksAPI.Dto;
using TasksAPI.Models;

namespace TasksAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UsersDto>();
            CreateMap<Objective, ObjectivesDto>();
        }
    }
}
