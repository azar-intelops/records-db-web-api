using MediatR;
using Application.Responses;

namespace Application.Queries.RecordDBDataConfigurationService
{
    public class GetRecordDBDataConfigurationByIdQuery : IRequest<RecordDBDataConfigurationResponse>
    {
        public int id { get; set; }

        public GetRecordDBDataConfigurationByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
