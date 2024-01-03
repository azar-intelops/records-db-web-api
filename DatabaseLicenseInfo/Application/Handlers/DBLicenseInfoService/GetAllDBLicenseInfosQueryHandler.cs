using AutoMapper;
using MediatR;
using Application.Queries.DBLicenseInfoService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.DBLicenseInfoService
{
    public class GetAllDBLicenseInfosQueryHandler : IRequestHandler<GetAllDBLicenseInfosQuery, List<DBLicenseInfoResponse>>
    {
        private readonly IDBLicenseInfoRepository _dblicenseInfoRepository;
        private readonly IMapper _mapper;
        public GetAllDBLicenseInfosQueryHandler(IDBLicenseInfoRepository dblicenseInfoRepository, IMapper mapper)
        {
            _dblicenseInfoRepository = dblicenseInfoRepository;
            _mapper = mapper;
        }
        public async Task<List<DBLicenseInfoResponse>> Handle(GetAllDBLicenseInfosQuery request, CancellationToken cancellationToken)
        {
            var generatedDBLicenseInfo = await _dblicenseInfoRepository.GetAllAsync();
            var dblicenseInfoEntity = _mapper.Map<List<DBLicenseInfoResponse>>(generatedDBLicenseInfo);
            return dblicenseInfoEntity;
        }
    }
}
