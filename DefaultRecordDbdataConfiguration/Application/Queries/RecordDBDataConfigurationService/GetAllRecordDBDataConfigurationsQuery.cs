using MediatR;
using Application.Responses;

namespace Application.Queries.RecordDBDataConfigurationService
{
    public class GetAllRecordDBDataConfigurationsQuery : IRequest<List<RecordDBDataConfigurationResponse>>
    {

    }
}
