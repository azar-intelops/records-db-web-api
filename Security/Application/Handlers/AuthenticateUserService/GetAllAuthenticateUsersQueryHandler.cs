using AutoMapper;
using MediatR;
using Application.Queries.AuthenticateUserService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AuthenticateUserService
{
    public class GetAllAuthenticateUsersQueryHandler : IRequestHandler<GetAllAuthenticateUsersQuery, List<AuthenticateUserResponse>>
    {
        private readonly IAuthenticateUserRepository _authenticateUserRepository;
        private readonly IMapper _mapper;
        public GetAllAuthenticateUsersQueryHandler(IAuthenticateUserRepository authenticateUserRepository, IMapper mapper)
        {
            _authenticateUserRepository = authenticateUserRepository;
            _mapper = mapper;
        }
        public async Task<List<AuthenticateUserResponse>> Handle(GetAllAuthenticateUsersQuery request, CancellationToken cancellationToken)
        {
            var generatedAuthenticateUser = await _authenticateUserRepository.GetAllAsync();
            var authenticateUserEntity = _mapper.Map<List<AuthenticateUserResponse>>(generatedAuthenticateUser);
            return authenticateUserEntity;
        }
    }
}
