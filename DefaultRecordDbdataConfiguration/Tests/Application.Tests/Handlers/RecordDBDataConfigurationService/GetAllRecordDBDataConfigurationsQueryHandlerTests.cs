using AutoMapper;
using Moq;
using Application.Handlers.RecordDBDataConfigurationService;
using Application.Queries.RecordDBDataConfigurationService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.RecordDBDataConfigurationService
{
    public class GetAllRecordDBDataConfigurationsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfRecordDBDataConfigurationResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RecordDBDataConfiguration, RecordDBDataConfigurationResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<RecordDBDataConfiguration> 
        {
            new RecordDBDataConfiguration { Id = 1 },
            new RecordDBDataConfiguration { Id = 2 }

        };

            var RepositoryMock = new Mock<IRecordDBDataConfigurationRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllRecordDBDataConfigurationsQuery();
            var handler = new GetAllRecordDBDataConfigurationsQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<RecordDBDataConfigurationResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
