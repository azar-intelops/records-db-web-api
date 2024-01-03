using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RecordDBDataConfigurationService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.RecordDBDataConfigurationService
{
    public class CreateRecordDBDataConfigurationCommandHandler : IRequestHandler<CreateRecordDBDataConfigurationCommand, int>
    {
        private readonly IRecordDBDataConfigurationRepository _recordDbdataConfigurationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRecordDBDataConfigurationCommandHandler> _logger;

        public CreateRecordDBDataConfigurationCommandHandler(IRecordDBDataConfigurationRepository recordDbdataConfigurationRepository, IMapper mapper, ILogger<CreateRecordDBDataConfigurationCommandHandler> logger)
        {
            _recordDbdataConfigurationRepository = recordDbdataConfigurationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateRecordDBDataConfigurationCommand request, CancellationToken cancellationToken)
        {
            var recordDbdataConfigurationEntity = _mapper.Map<RecordDBDataConfiguration>(request);

            /*****************************************************************************/
            var generatedRecordDBDataConfiguration = await _recordDbdataConfigurationRepository.AddAsync(recordDbdataConfigurationEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedRecordDBDataConfiguration} successfully created.");
            return generatedRecordDBDataConfiguration.Id;
        }
    }
}
