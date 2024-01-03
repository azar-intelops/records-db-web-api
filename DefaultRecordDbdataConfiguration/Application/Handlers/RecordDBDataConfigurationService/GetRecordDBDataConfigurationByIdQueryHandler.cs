using AutoMapper;
using MediatR;
using Application.Queries.RecordDBDataConfigurationService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.RecordDBDataConfigurationService
{
    public class GetRecordDBDataConfigurationByIdQueryHandler : IRequestHandler<GetRecordDBDataConfigurationByIdQuery, RecordDBDataConfigurationResponse>
    {
        private readonly IRecordDBDataConfigurationRepository _recordDbdataConfigurationRepository;
        private readonly IMapper _mapper;
        public GetRecordDBDataConfigurationByIdQueryHandler(IRecordDBDataConfigurationRepository recordDbdataConfigurationRepository, IMapper mapper)
        {
            _recordDbdataConfigurationRepository = recordDbdataConfigurationRepository;
            _mapper = mapper;
        }
        public async Task<RecordDBDataConfigurationResponse> Handle(GetRecordDBDataConfigurationByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedRecordDBDataConfiguration = await _recordDbdataConfigurationRepository.GetByIdAsync(request.id);
            var recordDbdataConfigurationEntity = _mapper.Map<RecordDBDataConfigurationResponse>(generatedRecordDBDataConfiguration);
            return recordDbdataConfigurationEntity;
        }
    }
}
