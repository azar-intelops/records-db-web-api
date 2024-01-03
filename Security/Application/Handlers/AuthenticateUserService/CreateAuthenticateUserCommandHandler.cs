using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthenticateUserService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AuthenticateUserService
{
    public class CreateAuthenticateUserCommandHandler : IRequestHandler<CreateAuthenticateUserCommand, int>
    {
        private readonly IAuthenticateUserRepository _authenticateUserRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAuthenticateUserCommandHandler> _logger;

        public CreateAuthenticateUserCommandHandler(IAuthenticateUserRepository authenticateUserRepository, IMapper mapper, ILogger<CreateAuthenticateUserCommandHandler> logger)
        {
            _authenticateUserRepository = authenticateUserRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateAuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var authenticateUserEntity = _mapper.Map<AuthenticateUser>(request);

            /*****************************************************************************/
            var generatedAuthenticateUser = await _authenticateUserRepository.AddAsync(authenticateUserEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedAuthenticateUser} successfully created.");
            return generatedAuthenticateUser.Id;
        }
    }
}
