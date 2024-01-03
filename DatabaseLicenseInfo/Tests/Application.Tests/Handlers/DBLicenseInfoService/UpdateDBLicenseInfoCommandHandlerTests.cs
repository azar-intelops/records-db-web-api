using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DBLicenseInfoService;
using Application.Exceptions;
using Application.Handlers.DBLicenseInfoService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DBLicenseInfoService
{
    public class UpdateDBLicenseInfoCommandHandlerTests
    {
        private readonly Mock<IDBLicenseInfoRepository> _dblicenseInfoRepository;
        private readonly Mock<ILogger<UpdateDBLicenseInfoCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateDBLicenseInfoCommandHandlerTests()
        {
            _dblicenseInfoRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsDBLicenseInfoNotFoundExceptionWhenDBLicenseInfoNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateDBLicenseInfoCommand { Id = Id }; // Create a request object

            _dblicenseInfoRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((DBLicenseInfo)null); // Mock the repository to return null

            var handler = new UpdateDBLicenseInfoCommandHandler(_dblicenseInfoRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<DBLicenseInfoNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
