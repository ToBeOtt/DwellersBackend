namespace Dwellers.Household.Tests.Features.Authentication.Commands
{
    //public class RegisterMemberToHouseCommandHandlerTests
    //{

    //    [Fact]
    //    public async Task Handle_ValidCommand_ReturnsRegisterMemberToHouseResult()
    //    {
    //        {
    //            var command = new RegisterMemberToHouseCommand(new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d5455b7"), "test@mail.com");

    //            var mockLogger = new Mock<ILogger<RegisterMemberToHouseCommandHandler>>();
    //            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //            var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
    //            var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //            var testuser = new DwellerUser();
    //            testuser.Email = "test@mail.com";

    //            var testhouse = new DomainDwellerHouse();
    //            testhouse.HouseId = new Guid("2edad9f4-9d45-4b97-b7c8-9abf1d5455b7");

    //            mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(testuser.Email)).ReturnsAsync(new DwellerUser());

    //            mockHouseQueryRepository.Setup(repo => repo.GetHouseByInvite(command.Invitation)).ReturnsAsync(new DomainDwellerHouse());

    //            mockHouseCommandRepository.Setup(repo => repo.AddHouseUser(It.IsAny<HouseUser>())).ReturnsAsync(true);

    //            var handler = new RegisterMemberToHouseCommandHandler(
    //                mockLogger.Object,
    //                mockUserQueryRepository.Object,
    //                mockHouseCommandRepository.Object,
    //                mockHouseQueryRepository.Object
    //                );

    //            var result = await handler.Handle(command, CancellationToken.None);

    //            Assert.NotNull(result);
    //            Assert.IsType<RegisterMemberToHouseResult>(result);
    //        }
    //    }

    //    // UserNotFound Exception
    //    [Fact]
    //    public async Task Handle_UserNotFound_ThrowsUserNotFoundException()
    //    {
    //        var command = new RegisterMemberToHouseCommand(new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d5455b7"), "test@mail.com");

    //        var mockLogger = new Mock<ILogger<RegisterMemberToHouseCommandHandler>>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
    //        var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //        var testuser = new DwellerUser();
    //        testuser.Email = "test@mail.com";

    //        mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(testuser.Email)).ReturnsAsync((DwellerUser)null);

    //        var handler = new RegisterMemberToHouseCommandHandler(
    //            mockLogger.Object,
    //            mockUserQueryRepository.Object,
    //            mockHouseCommandRepository.Object,
    //            mockHouseQueryRepository.Object
    //            );

    //        await Assert.ThrowsAsync<UserNotFoundException>(async () => {
    //            var result = await handler.Handle(command, CancellationToken.None);
    //        });
    //    }

    //    // Register Failed Exception
    //    [Fact]
    //    public async Task Handle_HousePersistanceFailed_ThrowsRegisterFailedException()
    //    {
    //        var command = new RegisterMemberToHouseCommand(new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d5455b7"), "test@mail.com");

    //        var mockLogger = new Mock<ILogger<RegisterMemberToHouseCommandHandler>>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
    //        var mockHouseQueryRepository = new Mock<IHouseQueryRepository>();

    //        mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new DwellerUser());

    //        mockHouseQueryRepository.Setup(repo => repo.GetHouseByInvite(command.Invitation)).ReturnsAsync((DomainDwellerHouse)null);

    //        mockHouseCommandRepository.Setup(repo => repo.AddHouseUser(It.IsAny<HouseUser>())).ReturnsAsync(false);

    //        var handler = new RegisterMemberToHouseCommandHandler(
    //            mockLogger.Object,
    //            mockUserQueryRepository.Object,
    //            mockHouseCommandRepository.Object,
    //            mockHouseQueryRepository.Object
    //            );

    //        await Assert.ThrowsAsync<RegisterFailedException>(async () => {
    //            var result = await handler.Handle(command, CancellationToken.None);
    //        });
    //    } 
    //}
}
