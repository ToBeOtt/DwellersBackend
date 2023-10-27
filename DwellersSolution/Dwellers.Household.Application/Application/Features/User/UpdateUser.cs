using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.User
{
    public record UpdateUserCommand(
        string UserId,
        IFormFile ProfilePhoto) : IRequest<UpdateUserResult>;


    public record UpdateUserResult(
        bool Success);


    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public UpdateUserCommandHandler(
             ILogger<UpdateUserCommandHandler> logger,
             IUserCommandRepository userCommandRepository,
             IUserQueryRepository userQueryRepository)
        {
            _logger = logger;
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<UpdateUserResult> Handle(UpdateUserCommand cmd, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(cmd.UserId);
            if (user is null)
            {
                _logger.LogError("An error occurred while updating the user profile photo.");
                throw new UserNotFoundException("User could not be found");
            }

            try // Convert file-data to byte[] to save to model-property
            {
                using (var memoryStream = new MemoryStream())
                {
                    await cmd.ProfilePhoto.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    user.ProfilePhoto = imageData;

                    var result = await _userCommandRepository.UpdateUser(user);

                    if (result)
                    {
                        return new UpdateUserResult(Success: true);
                    }

                    _logger.LogError("Failed to update user with profile photo.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user profile photo.");
                return new UpdateUserResult(Success: false);
            }

            return new UpdateUserResult(Success: false);
        }
    
    }

}
