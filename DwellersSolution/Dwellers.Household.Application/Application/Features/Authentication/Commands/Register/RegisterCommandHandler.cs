using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Features.Authentication.Commands.Register;
using Dwellers.Household.Application.Interfaces.Authentication;
using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(
            IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQueryRepository,
            ILogger<RegisterCommandHandler> logger)
        {
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
            _logger = logger;
        }
        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _userQueryRepository.GetUserByEmail(command.Email) is not null)
            {
                _logger.LogInformation("Email dubbel");
                throw new RegisterFailedException("Duplicate email"); // Change later for security reasons.
            }

            var user = new DwellerUser();
            user.UserName = command.Email;
            user.Alias = command.Alias;
            user.Email = command.Email;

            var result = await _userCommandRepository.AddUser(user, command.Password);
            if (!result.Succeeded)
            {
                _logger.LogInformation("Could not persist user to database");
                throw new RegisterFailedException("Persistance failed");
            }

            return new RegisterResult(
            user);
        }
    }
}
