using AutoMapper;
using Moq;
using Application.Handlers.DBLicenseInfoService;
using Application.Queries.DBLicenseInfoService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.DBLicenseInfoService
{
    public class GetDBLicenseInfoByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsDBLicenseInfoResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DBLicenseInfo, DBLicenseInfoResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new DBLicenseInfo { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IDBLicenseInfoRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetDBLicenseInfoByIdQuery(Id);
            var handler = new GetDBLicenseInfoByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DBLicenseInfoResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
