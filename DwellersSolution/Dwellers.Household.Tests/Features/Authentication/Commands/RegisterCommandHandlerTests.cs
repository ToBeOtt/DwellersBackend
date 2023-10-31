namespace Dwellers.Household.Tests.Features.Authentication.Commands
{
    //public class RegisterCommandHandlerTests
    //{
    //    [Fact]
    //    public async Task Handle_ValidCommand_ReturnsRegisterResult()
    //    {
    //        // Arrange
    //        var command = new RegisterCommand("test@example.com", "testuser", "testpassword");

    //        var mockUserCommandRepository = new Mock<IUserCommandRepository>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockLogger = new Mock<ILogger<RegisterCommandHandler>>();

    //        mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync((DwellerUser)null);

    //        mockUserCommandRepository.Setup(repo => repo.AddUser(It.IsAny<DwellerUser>(), It.IsAny<string>()))
    //            .ReturnsAsync(IdentityResult.Success);

    //        var handler = new RegisterCommandHandler(
    //            mockUserCommandRepository.Object,
    //            mockUserQueryRepository.Object,
    //            mockLogger.Object
    //        );

    //        // Act
    //        var result = await handler.Handle(command, CancellationToken.None);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.IsType<RegisterResult>(result);
    //    }


    //    // Register Failed Exception
    //    [Fact]
    //    public async Task Handle_EmailDuplicateOrPersistUserFailure_ThrowsRegisterFailedException()
    //    {
    //        // Arrange
    //        var command = new RegisterCommand("existing@example.com", "testuser", "testpassword");

    //        var mockUserCommandRepository = new Mock<IUserCommandRepository>();
    //        var mockUserQueryRepository = new Mock<IUserQueryRepository>();
    //        var mockLogger = new Mock<ILogger<RegisterCommandHandler>>();

    //        var identityError = new IdentityError { Code = "ErrorCode", Description = "Some failure message" };

    //        mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new DwellerUser());
    //        mockUserCommandRepository.Setup(repo => repo.AddUser(It.IsAny<DwellerUser>(), It.IsAny<string>()))
    //            .ReturnsAsync(IdentityResult.Failed(identityError));

    //        var handler = new RegisterCommandHandler(
    //            mockUserCommandRepository.Object,
    //            mockUserQueryRepository.Object,
    //            mockLogger.Object
    //        );

    //        // Act & Assert
    //        await Assert.ThrowsAsync<RegisterFailedException>(() => handler.Handle(command, CancellationToken.None));
    //    }
    //}
}
