using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.AuthenticateUserService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.AuthenticateUserService
{
    public class UpdateAuthenticateUserCommandHandler : IRequestHandler<UpdateAuthenticateUserCommand>
    {
        private readonly IAuthenticateUserRepository _authenticateUserRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAuthenticateUserCommandHandler> _logger;

        public UpdateAuthenticateUserCommandHandler(IAuthenticateUserRepository authenticateUserRepository, IMapper mapper, ILogger<UpdateAuthenticateUserCommandHandler> logger)
        {
            _authenticateUserRepository = authenticateUserRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateAuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var authenticateUserToUpdate = await _authenticateUserRepository.GetByIdAsync(request.Id);
            if (authenticateUserToUpdate == null)
            {
                throw new AuthenticateUserNotFoundException(nameof(AuthenticateUser), request.Id);
            }

            _mapper.Map(request, authenticateUserToUpdate, typeof(UpdateAuthenticateUserCommand), typeof(AuthenticateUser));
            await _authenticateUserRepository.UpdateAsync(authenticateUserToUpdate);
            _logger.LogInformation($"AuthenticateUser is successfully updated");
        }
    }
}
