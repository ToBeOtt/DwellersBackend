namespace Dwellers.Household.Tests.Features.Authentication.Queries
{
    //public class GetUserDetailsQueryHandlerTest
    //{
    //    [Fact]
    //    public async Task Handle_ValidQuery_ReturnsGetUserDetailsResult()
    //    {
    //        {
    //            var query = new FetchUserDetailsQuery("userid123", new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d7755b7"));

    //            var mockLogger = new Mock<ILogger<GetUserDetails>>();
    //            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //            var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //            var testuser = new DwellerUser();
    //            testuser.Id = query.UserId;

    //            var testhouse = new DomainDwellerHouse();
    //            testhouse.HouseId = query.HouseId;

    //            mockUserQueryRepository.Setup(repo => repo.GetUserById(testuser.Id)).ReturnsAsync(testuser);

    //            mockHouseQueryRepository.Setup(repo => repo.GetHouseById(testhouse.HouseId)).ReturnsAsync(testhouse);


    //            var handler = new GetUserDetails(
    //                mockLogger.Object,
    //                mockUserQueryRepository.Object,
    //                mockHouseQueryRepository.Object
    //                );

    //            var result = await handler.Handle(query, CancellationToken.None);

    //            Assert.NotNull(result);
    //            Assert.IsType<GetUserDetailsResult>(result);
    //        }
    //    }

    //    // EntityNotFound Exception
    //    [Fact]
    //    public async Task Handle_EntityNotFound_ThrowsEntityNotFoundException()
    //    {
    //        var query = new GetUserDetailsQuery("userid123", new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d7755b7"));

    //        var mockLogger = new Mock<ILogger<GetUserDetails>>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //        var testuser = new DwellerUser();
    //        testuser.Id = query.UserId;

    //        var testhouse = new DomainDwellerHouse();
    //        testhouse.HouseId = query.HouseId;

    //        mockUserQueryRepository.Setup(repo => repo.GetUserById(It.IsAny<string>())).ReturnsAsync((DwellerUser)null);

    //        mockHouseQueryRepository.Setup(repo => repo.GetHouseById(It.IsAny<Guid>())).ReturnsAsync((DomainDwellerHouse)null);


    //        var handler = new GetUserDetails(
    //                mockLogger.Object,
    //                mockUserQueryRepository.Object,
    //                mockHouseQueryRepository.Object
    //                );

    //        await Assert.ThrowsAsync<EntityNotFoundException>(async () => {
    //            var result = await handler.Handle(query, CancellationToken.None);
    //        });
    //    }
    //}
}
