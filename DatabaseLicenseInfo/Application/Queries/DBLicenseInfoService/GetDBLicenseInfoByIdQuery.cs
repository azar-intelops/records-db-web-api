using MediatR;
using Application.Responses;

namespace Application.Queries.DBLicenseInfoService
{
    public class GetDBLicenseInfoByIdQuery : IRequest<DBLicenseInfoResponse>
    {
        public int id { get; set; }

        public GetDBLicenseInfoByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
