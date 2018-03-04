using AutoMapper;
using JR_API.Dtos;
using JR_API.Entities;

namespace JR_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }
}