using MediatR;

namespace Application.Commands.DBLicenseInfoService
{
    public class DeleteDBLicenseInfoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
