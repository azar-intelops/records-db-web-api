using AutoMapper;
using MediatR;
using Application.Queries.DBLicenseInfoService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.DBLicenseInfoService
{
    public class GetDBLicenseInfoByIdQueryHandler : IRequestHandler<GetDBLicenseInfoByIdQuery, DBLicenseInfoResponse>
    {
        private readonly IDBLicenseInfoRepository _dblicenseInfoRepository;
        private readonly IMapper _mapper;
        public GetDBLicenseInfoByIdQueryHandler(IDBLicenseInfoRepository dblicenseInfoRepository, IMapper mapper)
        {
            _dblicenseInfoRepository = dblicenseInfoRepository;
            _mapper = mapper;
        }
        public async Task<DBLicenseInfoResponse> Handle(GetDBLicenseInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedDBLicenseInfo = await _dblicenseInfoRepository.GetByIdAsync(request.id);
            var dblicenseInfoEntity = _mapper.Map<DBLicenseInfoResponse>(generatedDBLicenseInfo);
            return dblicenseInfoEntity;
        }
    }
}
