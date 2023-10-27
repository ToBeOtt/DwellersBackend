using Dwellers.Household.Application.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Authentication.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Features.Authentication.Commands.RegisterHouse;
using Dwellers.Household.Application.Features.Authentication.Commands.RegisterMemberToHouse;
using Dwellers.Household.Application.Interfaces.Household.Chat;
using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Microsoft.Extensions.Logging;
using Moq;

namespace Dwellers.Household.Tests.Features.Authentication.Commands
{
    public class RegisterHouseCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsRegisterHouseResult()
        {
            var command = new RegisterHouseCommand("testname", "testdescription", "test@mail.com");

            var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
            var mockLogger = new Mock<ILogger<RegisterHouseCommandHandler>>();
            var mockChatCommandRepository = new Mock<IChatCommandRepository>();

            mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new DwellerUser());

            mockHouseCommandRepository.Setup(repo => repo.AddHouse(It.IsAny<House>())).ReturnsAsync(true);

            mockHouseCommandRepository.Setup(repo => repo.AddHouseUser(It.IsAny<HouseUser>())).ReturnsAsync(true);

            var handler = new RegisterHouseCommandHandler(
                mockLogger.Object,
                mockUserQueryRepository.Object,
                mockHouseCommandRepository.Object,
                mockChatCommandRepository.Object
                );

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<RegisterHouseResult>(result);
        }

        // UserNotFound Exception
        [Fact]
        public async Task Handle_UserNotFound_ThrowsUserNotFoundException()
        {
            var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
            var mockLogger = new Mock<ILogger<RegisterHouseCommandHandler>>();
            var mockChatCommandRepository = new Mock<IChatCommandRepository>();

            mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync((DwellerUser)null);

            var command = new RegisterHouseCommand("testname", "testdescription", "test@mail.com");

            var handler = new RegisterHouseCommandHandler(
                mockLogger.Object,
                mockUserQueryRepository.Object,
                mockHouseCommandRepository.Object,
                mockChatCommandRepository.Object
                );

            await Assert.ThrowsAsync<UserNotFoundException>(async () => {
                var result = await handler.Handle(command, CancellationToken.None);
            });
        }

        // Register Failed Exception
        [Fact]
        public async Task Handle_HousePersistanceFailed_ThrowsRegisterFailedException()
        {
            var mockUserQueryRepository = new Mock<IUserQueryRepository>();
            var mockHouseCommandRepository = new Mock<IHouseCommandRepository>();
            var mockLogger = new Mock<ILogger<RegisterHouseCommandHandler>>();
            var mockChatCommandRepository = new Mock<IChatCommandRepository>();

            mockUserQueryRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).ReturnsAsync(new DwellerUser());

            mockHouseCommandRepository.Setup(repo => repo.AddHouse(It.IsAny<House>())).ReturnsAsync(false);

            var command = new RegisterHouseCommand("test@example.com", "HouseName", "HouseDescription");

            var handler = new RegisterHouseCommandHandler(
                mockLogger.Object,
                mockUserQueryRepository.Object,
                mockHouseCommandRepository.Object,
                mockChatCommandRepository.Object
                );

            await Assert.ThrowsAsync<RegisterFailedException>(async () => {
                var result = await handler.Handle(command, CancellationToken.None);
            });
        }
    }
}
