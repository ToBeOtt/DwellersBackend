namespace Dwellers.Household.Tests.Features.Authentication.Queries
{
    //public class LoginQueryHandlerTest
    //{
    //    [Fact]
    //    public async Task Handle_ValidQuery_ReturnsLoginResult()
    //    {
    //        {
    //            var query = new LoginQuery("test@mail.com", "testPassword");

    //            var mockLogger = new Mock<ILogger<LoginQueryHandler>>();
    //            var mockJwtTokenRepository = new Mock<IJwtTokenRepository>();
    //            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //            var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //            var testuser = new DwellerUser();
    //            testuser.Email = "test@mail.com";
    //            testuser.Id = "123id";

    //            var testHouseUser = new HouseUser();
    //            testHouseUser.HouseId = new Guid("2edad9f4-9d45-4b97-b7c8-9abf1d5455b7");
    //            testHouseUser.UserId = testuser.Id;

    //            mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(testuser.Email)).ReturnsAsync(testuser);

    //            mockHouseQueryRepository.Setup(repo => repo.GetHouseUserByUserID(testuser.Id)).ReturnsAsync(testHouseUser);

    //            mockUserQueryRepository.Setup(repo => repo.CheckLoginCredentials(It.IsAny<string>(), It.IsAny<string>()))
    //                   .ReturnsAsync(SignInResult.Success);

    //            var handler = new LoginQueryHandler(
    //                mockLogger.Object,
    //                mockJwtTokenRepository.Object,
    //                mockUserQueryRepository.Object,
    //                mockHouseQueryRepository.Object
    //                );

    //            var result = await handler.Handle(query, CancellationToken.None);

    //            Assert.NotNull(result);
    //            Assert.IsType<LoginResult>(result);
    //        }
    //    }

    //    // LoginFailed Exception
    //    [Fact]
    //    public async Task Handle_LoginFailed_ThrowsLoginFailedException()
    //    {
    //        var query = new LoginQuery("test@mail.com", "testPassword");

    //        var mockLogger = new Mock<ILogger<LoginQueryHandler>>();
    //        var mockJwtTokenRepository = new Mock<IJwtTokenRepository>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //        var testuser = new DwellerUser();
    //        testuser.Email = "test@mail.com";
    //        testuser.Id = "123id";

    //        mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(testuser.Email)).ReturnsAsync((DwellerUser)null);

    //        mockHouseQueryRepository.Setup(repo => repo.GetHouseUserByUserID(testuser.Id)).ReturnsAsync((HouseUser)null);

    //        mockUserQueryRepository.Setup(repo => repo.CheckLoginCredentials(It.IsAny<string>(), It.IsAny<string>()))
    //               .ReturnsAsync(SignInResult.Failed);

    //        var handler = new LoginQueryHandler(
    //            mockLogger.Object,
    //            mockJwtTokenRepository.Object,
    //            mockUserQueryRepository.Object,
    //            mockHouseQueryRepository.Object
    //            );

    //        await Assert.ThrowsAsync<LoginFailedException>(async () => {
    //            var result = await handler.Handle(query, CancellationToken.None);
    //        });
    //    }
    //}
}
