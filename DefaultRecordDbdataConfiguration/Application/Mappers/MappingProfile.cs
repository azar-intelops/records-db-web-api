using AutoMapper;

using Application.Commands.RecordDBDataConfigurationService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<RecordDBDataConfiguration, RecordDBDataConfigurationResponse>().ReverseMap();
            CreateMap<RecordDBDataConfiguration, CreateRecordDBDataConfigurationCommand>().ReverseMap();
            CreateMap<RecordDBDataConfiguration, UpdateRecordDBDataConfigurationCommand>().ReverseMap();
          
        }
    }
}
