using MediatR;

namespace Application.Commands.RecordDBDataConfigurationService
{
    public class DeleteRecordDBDataConfigurationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
