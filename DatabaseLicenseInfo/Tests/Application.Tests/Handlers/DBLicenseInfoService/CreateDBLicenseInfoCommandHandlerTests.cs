using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.DBLicenseInfoService;
using Application.Handlers.DBLicenseInfoService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DBLicenseInfoService
{
    public class CreateDBLicenseInfoCommandHandlerTests
    {
        private readonly Mock<IDBLicenseInfoRepository> _dblicenseInfoRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateDBLicenseInfoCommandHandler>> _logger;

        public CreateDBLicenseInfoCommandHandlerTests()
        {
            _dblicenseInfoRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateDBLicenseInfoCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<DBLicenseInfo>(request))
                .Returns(new DBLicenseInfo()); 

            _dblicenseInfoRepository
                .Setup(r => r.AddAsync(It.IsAny<DBLicenseInfo>()))
                .ReturnsAsync(new DBLicenseInfo { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateDBLicenseInfoCommandHandler>>();
            var handler = new CreateDBLicenseInfoCommandHandler(_dblicenseInfoRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
