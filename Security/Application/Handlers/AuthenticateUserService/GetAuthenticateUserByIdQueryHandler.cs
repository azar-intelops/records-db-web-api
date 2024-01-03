using AutoMapper;
using MediatR;
using Application.Queries.AuthenticateUserService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.AuthenticateUserService
{
    public class GetAuthenticateUserByIdQueryHandler : IRequestHandler<GetAuthenticateUserByIdQuery, AuthenticateUserResponse>
    {
        private readonly IAuthenticateUserRepository _authenticateUserRepository;
        private readonly IMapper _mapper;
        public GetAuthenticateUserByIdQueryHandler(IAuthenticateUserRepository authenticateUserRepository, IMapper mapper)
        {
            _authenticateUserRepository = authenticateUserRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticateUserResponse> Handle(GetAuthenticateUserByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedAuthenticateUser = await _authenticateUserRepository.GetByIdAsync(request.id);
            var authenticateUserEntity = _mapper.Map<AuthenticateUserResponse>(generatedAuthenticateUser);
            return authenticateUserEntity;
        }
    }
}
