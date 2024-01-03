using AutoMapper;
using Moq;
using Application.Handlers.AuthenticateUserService;
using Application.Queries.AuthenticateUserService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthenticateUserService
{
    public class GetAllAuthenticateUsersQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfAuthenticateUserResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthenticateUser, AuthenticateUserResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<AuthenticateUser> 
        {
            new AuthenticateUser { Id = 1 },
            new AuthenticateUser { Id = 2 }

        };

            var RepositoryMock = new Mock<IAuthenticateUserRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllAuthenticateUsersQuery();
            var handler = new GetAllAuthenticateUsersQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<AuthenticateUserResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
