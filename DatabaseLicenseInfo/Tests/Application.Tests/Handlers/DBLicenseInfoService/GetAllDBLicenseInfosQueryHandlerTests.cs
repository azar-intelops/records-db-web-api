using AutoMapper;
using Moq;
using Application.Handlers.DBLicenseInfoService;
using Application.Queries.DBLicenseInfoService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DBLicenseInfoService
{
    public class GetAllDBLicenseInfosQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfDBLicenseInfoResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DBLicenseInfo, DBLicenseInfoResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<DBLicenseInfo> 
        {
            new DBLicenseInfo { Id = 1 },
            new DBLicenseInfo { Id = 2 }

        };

            var RepositoryMock = new Mock<IDBLicenseInfoRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllDBLicenseInfosQuery();
            var handler = new GetAllDBLicenseInfosQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<DBLicenseInfoResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
