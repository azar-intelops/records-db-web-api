using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RecordDBDataConfigurationService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.RecordDBDataConfigurationService
{
    public class UpdateRecordDBDataConfigurationCommandHandler : IRequestHandler<UpdateRecordDBDataConfigurationCommand>
    {
        private readonly IRecordDBDataConfigurationRepository _recordDbdataConfigurationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRecordDBDataConfigurationCommandHandler> _logger;

        public UpdateRecordDBDataConfigurationCommandHandler(IRecordDBDataConfigurationRepository recordDbdataConfigurationRepository, IMapper mapper, ILogger<UpdateRecordDBDataConfigurationCommandHandler> logger)
        {
            _recordDbdataConfigurationRepository = recordDbdataConfigurationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateRecordDBDataConfigurationCommand request, CancellationToken cancellationToken)
        {
            var recordDbdataConfigurationToUpdate = await _recordDbdataConfigurationRepository.GetByIdAsync(request.Id);
            if (recordDbdataConfigurationToUpdate == null)
            {
                throw new RecordDBDataConfigurationNotFoundException(nameof(RecordDBDataConfiguration), request.Id);
            }

            _mapper.Map(request, recordDbdataConfigurationToUpdate, typeof(UpdateRecordDBDataConfigurationCommand), typeof(RecordDBDataConfiguration));
            await _recordDbdataConfigurationRepository.UpdateAsync(recordDbdataConfigurationToUpdate);
            _logger.LogInformation($"RecordDBDataConfiguration is successfully updated");
        }
    }
}
