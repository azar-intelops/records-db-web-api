using MediatR;
using Application.Responses;

namespace Application.Queries.DBLicenseInfoService
{
    public class GetAllDBLicenseInfosQuery : IRequest<List<DBLicenseInfoResponse>>
    {

    }
}
