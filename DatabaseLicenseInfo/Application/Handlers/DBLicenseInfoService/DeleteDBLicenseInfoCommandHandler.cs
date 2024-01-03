using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DBLicenseInfoService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.DBLicenseInfoService
{
    public class DeleteDBLicenseInfoCommandHandler : IRequestHandler<DeleteDBLicenseInfoCommand>
    {
        private readonly IDBLicenseInfoRepository _dblicenseInfoRepository;
        private readonly ILogger<DeleteDBLicenseInfoCommandHandler> _logger;

        public DeleteDBLicenseInfoCommandHandler(IDBLicenseInfoRepository dblicenseInfoRepository, ILogger<DeleteDBLicenseInfoCommandHandler> logger)
        {
            _dblicenseInfoRepository = dblicenseInfoRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteDBLicenseInfoCommand request, CancellationToken cancellationToken)
        {
            var dblicenseInfoToDelete = await _dblicenseInfoRepository.GetByIdAsync(request.Id);
            if (dblicenseInfoToDelete == null)
            {
                throw new DBLicenseInfoNotFoundException(nameof(DBLicenseInfo), request.Id);
            }

            await _dblicenseInfoRepository.DeleteAsync(dblicenseInfoToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
