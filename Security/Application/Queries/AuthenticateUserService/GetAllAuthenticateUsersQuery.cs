using MediatR;
using Application.Responses;

namespace Application.Queries.AuthenticateUserService
{
    public class GetAllAuthenticateUsersQuery : IRequest<List<AuthenticateUserResponse>>
    {

    }
}
