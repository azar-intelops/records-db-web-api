using AutoMapper;

using Application.Commands.AuthenticateUserService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<AuthenticateUser, AuthenticateUserResponse>().ReverseMap();
            CreateMap<AuthenticateUser, CreateAuthenticateUserCommand>().ReverseMap();
            CreateMap<AuthenticateUser, UpdateAuthenticateUserCommand>().ReverseMap();
          
        }
    }
}
