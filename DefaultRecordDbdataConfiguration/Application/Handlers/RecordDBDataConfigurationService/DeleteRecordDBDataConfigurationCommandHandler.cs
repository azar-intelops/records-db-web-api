using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.RecordDBDataConfigurationService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.RecordDBDataConfigurationService
{
    public class DeleteRecordDBDataConfigurationCommandHandler : IRequestHandler<DeleteRecordDBDataConfigurationCommand>
    {
        private readonly IRecordDBDataConfigurationRepository _recordDbdataConfigurationRepository;
        private readonly ILogger<DeleteRecordDBDataConfigurationCommandHandler> _logger;

        public DeleteRecordDBDataConfigurationCommandHandler(IRecordDBDataConfigurationRepository recordDbdataConfigurationRepository, ILogger<DeleteRecordDBDataConfigurationCommandHandler> logger)
        {
            _recordDbdataConfigurationRepository = recordDbdataConfigurationRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteRecordDBDataConfigurationCommand request, CancellationToken cancellationToken)
        {
            var recordDbdataConfigurationToDelete = await _recordDbdataConfigurationRepository.GetByIdAsync(request.Id);
            if (recordDbdataConfigurationToDelete == null)
            {
                throw new RecordDBDataConfigurationNotFoundException(nameof(RecordDBDataConfiguration), request.Id);
            }

            await _recordDbdataConfigurationRepository.DeleteAsync(recordDbdataConfigurationToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
