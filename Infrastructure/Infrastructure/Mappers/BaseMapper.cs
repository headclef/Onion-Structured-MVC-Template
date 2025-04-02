using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Mappers
{
    public class BaseMapper : Profile
    {
        public BaseMapper()
        {
            // CreateMap<Source, Destination>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();

            CreateMap<BlockedEmail, BlockedEmailDto>().ReverseMap();
        }
    }
}