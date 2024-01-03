using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DBLicenseInfoService;
using Application.Exceptions;
using Application.Handlers.DBLicenseInfoService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DBLicenseInfoService
{
    public class DeleteDBLicenseInfoCommandHandlerTests
    {
        private readonly Mock<IDBLicenseInfoRepository> _dblicenseInfoRepository;
        private readonly Mock<ILogger<DeleteDBLicenseInfoCommandHandler>> _logger;

        public DeleteDBLicenseInfoCommandHandlerTests()
        {
            _dblicenseInfoRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsDBLicenseInfoNotFoundExceptionWhenDBLicenseInfoNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteDBLicenseInfoCommand { Id = Id }; // Create a request object

            _dblicenseInfoRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((DBLicenseInfo)null); // Mock the repository to return null

            var handler = new DeleteDBLicenseInfoCommandHandler(_dblicenseInfoRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<DBLicenseInfoNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
