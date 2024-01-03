using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.RecordDBDataConfigurationService;
using Application.Handlers.RecordDBDataConfigurationService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RecordDBDataConfigurationService
{
    public class CreateRecordDBDataConfigurationCommandHandlerTests
    {
        private readonly Mock<IRecordDBDataConfigurationRepository> _recordDbdataConfigurationRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateRecordDBDataConfigurationCommandHandler>> _logger;

        public CreateRecordDBDataConfigurationCommandHandlerTests()
        {
            _recordDbdataConfigurationRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateRecordDBDataConfigurationCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<RecordDBDataConfiguration>(request))
                .Returns(new RecordDBDataConfiguration()); 

            _recordDbdataConfigurationRepository
                .Setup(r => r.AddAsync(It.IsAny<RecordDBDataConfiguration>()))
                .ReturnsAsync(new RecordDBDataConfiguration { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateRecordDBDataConfigurationCommandHandler>>();
            var handler = new CreateRecordDBDataConfigurationCommandHandler(_recordDbdataConfigurationRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
