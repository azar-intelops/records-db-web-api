using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.RecordDBDataConfigurationService;
using Application.Exceptions;
using Application.Handlers.RecordDBDataConfigurationService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RecordDBDataConfigurationService
{
    public class DeleteRecordDBDataConfigurationCommandHandlerTests
    {
        private readonly Mock<IRecordDBDataConfigurationRepository> _recordDbdataConfigurationRepository;
        private readonly Mock<ILogger<DeleteRecordDBDataConfigurationCommandHandler>> _logger;

        public DeleteRecordDBDataConfigurationCommandHandlerTests()
        {
            _recordDbdataConfigurationRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsRecordDBDataConfigurationNotFoundExceptionWhenRecordDBDataConfigurationNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteRecordDBDataConfigurationCommand { Id = Id }; // Create a request object

            _recordDbdataConfigurationRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((RecordDBDataConfiguration)null); // Mock the repository to return null

            var handler = new DeleteRecordDBDataConfigurationCommandHandler(_recordDbdataConfigurationRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<RecordDBDataConfigurationNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
