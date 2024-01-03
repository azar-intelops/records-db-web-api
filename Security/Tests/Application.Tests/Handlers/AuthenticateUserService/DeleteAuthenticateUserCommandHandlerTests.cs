using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AuthenticateUserService;
using Application.Exceptions;
using Application.Handlers.AuthenticateUserService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthenticateUserService
{
    public class DeleteAuthenticateUserCommandHandlerTests
    {
        private readonly Mock<IAuthenticateUserRepository> _authenticateUserRepository;
        private readonly Mock<ILogger<DeleteAuthenticateUserCommandHandler>> _logger;

        public DeleteAuthenticateUserCommandHandlerTests()
        {
            _authenticateUserRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsAuthenticateUserNotFoundExceptionWhenAuthenticateUserNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteAuthenticateUserCommand { Id = Id }; // Create a request object

            _authenticateUserRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((AuthenticateUser)null); // Mock the repository to return null

            var handler = new DeleteAuthenticateUserCommandHandler(_authenticateUserRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<AuthenticateUserNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
