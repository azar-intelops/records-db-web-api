using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.DBLicenseInfoService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.DBLicenseInfoService
{
    public class CreateDBLicenseInfoCommandHandler : IRequestHandler<CreateDBLicenseInfoCommand, int>
    {
        private readonly IDBLicenseInfoRepository _dblicenseInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDBLicenseInfoCommandHandler> _logger;

        public CreateDBLicenseInfoCommandHandler(IDBLicenseInfoRepository dblicenseInfoRepository, IMapper mapper, ILogger<CreateDBLicenseInfoCommandHandler> logger)
        {
            _dblicenseInfoRepository = dblicenseInfoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateDBLicenseInfoCommand request, CancellationToken cancellationToken)
        {
            var dblicenseInfoEntity = _mapper.Map<DBLicenseInfo>(request);

            /*****************************************************************************/
            var generatedDBLicenseInfo = await _dblicenseInfoRepository.AddAsync(dblicenseInfoEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedDBLicenseInfo} successfully created.");
            return generatedDBLicenseInfo.Id;
        }
    }
}
