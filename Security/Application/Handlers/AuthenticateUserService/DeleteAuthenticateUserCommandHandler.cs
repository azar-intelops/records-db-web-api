using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthenticateUserService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.AuthenticateUserService
{
    public class DeleteAuthenticateUserCommandHandler : IRequestHandler<DeleteAuthenticateUserCommand>
    {
        private readonly IAuthenticateUserRepository _authenticateUserRepository;
        private readonly ILogger<DeleteAuthenticateUserCommandHandler> _logger;

        public DeleteAuthenticateUserCommandHandler(IAuthenticateUserRepository authenticateUserRepository, ILogger<DeleteAuthenticateUserCommandHandler> logger)
        {
            _authenticateUserRepository = authenticateUserRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteAuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var authenticateUserToDelete = await _authenticateUserRepository.GetByIdAsync(request.Id);
            if (authenticateUserToDelete == null)
            {
                throw new AuthenticateUserNotFoundException(nameof(AuthenticateUser), request.Id);
            }

            await _authenticateUserRepository.DeleteAsync(authenticateUserToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
