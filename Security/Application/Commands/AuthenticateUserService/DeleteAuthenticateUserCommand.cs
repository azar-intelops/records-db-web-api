using MediatR;

namespace Application.Commands.AuthenticateUserService
{
    public class DeleteAuthenticateUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
