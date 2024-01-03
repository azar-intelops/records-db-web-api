using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.AuthenticateUserService;
using Application.Handlers.AuthenticateUserService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthenticateUserService
{
    public class CreateAuthenticateUserCommandHandlerTests
    {
        private readonly Mock<IAuthenticateUserRepository> _authenticateUserRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateAuthenticateUserCommandHandler>> _logger;

        public CreateAuthenticateUserCommandHandlerTests()
        {
            _authenticateUserRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateAuthenticateUserCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<AuthenticateUser>(request))
                .Returns(new AuthenticateUser()); 

            _authenticateUserRepository
                .Setup(r => r.AddAsync(It.IsAny<AuthenticateUser>()))
                .ReturnsAsync(new AuthenticateUser { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateAuthenticateUserCommandHandler>>();
            var handler = new CreateAuthenticateUserCommandHandler(_authenticateUserRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
