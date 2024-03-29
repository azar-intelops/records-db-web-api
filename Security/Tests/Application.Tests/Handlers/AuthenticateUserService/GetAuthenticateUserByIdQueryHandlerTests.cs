﻿using AutoMapper;
using Moq;
using Application.Handlers.AuthenticateUserService;
using Application.Queries.AuthenticateUserService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.AuthenticateUserService
{
    public class GetAuthenticateUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsAuthenticateUserResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthenticateUser, AuthenticateUserResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new AuthenticateUser { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IAuthenticateUserRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetAuthenticateUserByIdQuery(Id);
            var handler = new GetAuthenticateUserByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AuthenticateUserResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
