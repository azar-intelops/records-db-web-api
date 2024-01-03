using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DBLicenseInfoService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.DBLicenseInfoService
{
    public class UpdateDBLicenseInfoCommandHandler : IRequestHandler<UpdateDBLicenseInfoCommand>
    {
        private readonly IDBLicenseInfoRepository _dblicenseInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDBLicenseInfoCommandHandler> _logger;

        public UpdateDBLicenseInfoCommandHandler(IDBLicenseInfoRepository dblicenseInfoRepository, IMapper mapper, ILogger<UpdateDBLicenseInfoCommandHandler> logger)
        {
            _dblicenseInfoRepository = dblicenseInfoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateDBLicenseInfoCommand request, CancellationToken cancellationToken)
        {
            var dblicenseInfoToUpdate = await _dblicenseInfoRepository.GetByIdAsync(request.Id);
            if (dblicenseInfoToUpdate == null)
            {
                throw new DBLicenseInfoNotFoundException(nameof(DBLicenseInfo), request.Id);
            }

            _mapper.Map(request, dblicenseInfoToUpdate, typeof(UpdateDBLicenseInfoCommand), typeof(DBLicenseInfo));
            await _dblicenseInfoRepository.UpdateAsync(dblicenseInfoToUpdate);
            _logger.LogInformation($"DBLicenseInfo is successfully updated");
        }
    }
}
