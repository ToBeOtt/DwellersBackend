using Dwellers.Household.Application.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Microsoft.Extensions.Logging;
using Moq;

namespace Dwellers.Household.Tests.Features.Authentication.Queries
{
    public class GetUserDetailsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidQuery_ReturnsGetUserDetailsResult()
        {
            {
                var query = new GetUserDetailsQuery("userid123", new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d7755b7"));

                var mockLogger = new Mock<ILogger<GetUserDetailsHandler>>();
                var mockUserQueryRepository = new Mock<IUserQueryRepository>();
                var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

                var testuser = new DwellerUser();
                testuser.Id = query.UserId;

                var testhouse = new House();
                testhouse.HouseId = query.HouseId;

                mockUserQueryRepository.Setup(repo => repo.GetUserById(testuser.Id)).ReturnsAsync(testuser);

                mockHouseQueryRepository.Setup(repo => repo.GetHouseById(testhouse.HouseId)).ReturnsAsync(testhouse);


                var handler = new GetUserDetailsHandler(
                    mockLogger.Object,
                    mockUserQueryRepository.Object,
                    mockHouseQueryRepository.Object
                    );

                var result = await handler.Handle(query, CancellationToken.None);

                Assert.NotNull(result);
                Assert.IsType<GetUserDetailsResult>(result);
            }
        }

        // EntityNotFound Exception
        [Fact]
        public async Task Handle_EntityNotFound_ThrowsEntityNotFoundException()
        {
            var query = new GetUserDetailsQuery("userid123", new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d7755b7"));

            var mockLogger = new Mock<ILogger<GetUserDetailsHandler>>();
            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
            var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

            var testuser = new DwellerUser();
            testuser.Id = query.UserId;

            var testhouse = new House();
            testhouse.HouseId = query.HouseId;

            mockUserQueryRepository.Setup(repo => repo.GetUserById(It.IsAny<string>())).ReturnsAsync((DwellerUser)null);

            mockHouseQueryRepository.Setup(repo => repo.GetHouseById(It.IsAny<Guid>())).ReturnsAsync((House)null);


            var handler = new GetUserDetailsHandler(
                    mockLogger.Object,
                    mockUserQueryRepository.Object,
                    mockHouseQueryRepository.Object
                    );

            await Assert.ThrowsAsync<EntityNotFoundException>(async () => {
                var result = await handler.Handle(query, CancellationToken.None);
            });
        }
    }
}
