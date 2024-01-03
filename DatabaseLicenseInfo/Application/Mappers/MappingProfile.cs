using AutoMapper;

using Application.Commands.DBLicenseInfoService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<DBLicenseInfo, DBLicenseInfoResponse>().ReverseMap();
            CreateMap<DBLicenseInfo, CreateDBLicenseInfoCommand>().ReverseMap();
            CreateMap<DBLicenseInfo, UpdateDBLicenseInfoCommand>().ReverseMap();
          
        }
    }
}
