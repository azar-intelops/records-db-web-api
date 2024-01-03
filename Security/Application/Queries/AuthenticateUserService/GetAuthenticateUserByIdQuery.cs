using MediatR;
using Application.Responses;

namespace Application.Queries.AuthenticateUserService
{
    public class GetAuthenticateUserByIdQuery : IRequest<AuthenticateUserResponse>
    {
        public int id { get; set; }

        public GetAuthenticateUserByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
