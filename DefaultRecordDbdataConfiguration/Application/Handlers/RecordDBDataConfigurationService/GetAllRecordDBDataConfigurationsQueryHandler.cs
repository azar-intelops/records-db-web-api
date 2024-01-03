using AutoMapper;
using MediatR;
using Application.Queries.RecordDBDataConfigurationService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.RecordDBDataConfigurationService
{
    public class GetAllRecordDBDataConfigurationsQueryHandler : IRequestHandler<GetAllRecordDBDataConfigurationsQuery, List<RecordDBDataConfigurationResponse>>
    {
        private readonly IRecordDBDataConfigurationRepository _recordDbdataConfigurationRepository;
        private readonly IMapper _mapper;
        public GetAllRecordDBDataConfigurationsQueryHandler(IRecordDBDataConfigurationRepository recordDbdataConfigurationRepository, IMapper mapper)
        {
            _recordDbdataConfigurationRepository = recordDbdataConfigurationRepository;
            _mapper = mapper;
        }
        public async Task<List<RecordDBDataConfigurationResponse>> Handle(GetAllRecordDBDataConfigurationsQuery request, CancellationToken cancellationToken)
        {
            var generatedRecordDBDataConfiguration = await _recordDbdataConfigurationRepository.GetAllAsync();
            var recordDbdataConfigurationEntity = _mapper.Map<List<RecordDBDataConfigurationResponse>>(generatedRecordDBDataConfiguration);
            return recordDbdataConfigurationEntity;
        }
    }
}
