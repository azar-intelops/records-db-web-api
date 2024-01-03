using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AuthenticateUserService;
using Application.Exceptions;
using Application.Handlers.AuthenticateUserService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthenticateUserService
{
    public class UpdateAuthenticateUserCommandHandlerTests
    {
        private readonly Mock<IAuthenticateUserRepository> _authenticateUserRepository;
        private readonly Mock<ILogger<UpdateAuthenticateUserCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateAuthenticateUserCommandHandlerTests()
        {
            _authenticateUserRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsAuthenticateUserNotFoundExceptionWhenAuthenticateUserNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateAuthenticateUserCommand { Id = Id }; // Create a request object

            _authenticateUserRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((AuthenticateUser)null); // Mock the repository to return null

            var handler = new UpdateAuthenticateUserCommandHandler(_authenticateUserRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<AuthenticateUserNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
