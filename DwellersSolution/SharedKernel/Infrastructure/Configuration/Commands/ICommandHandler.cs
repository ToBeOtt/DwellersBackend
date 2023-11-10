using SharedKernel.Application.ServiceResponse;

namespace SharedKernel.Infrastructure.Configuration.Commands
{
    public interface ICommandHandler<TCommand, TCommandResult>
    {
        Task<ServiceResponse<TCommandResult>> Handle(TCommand command, CancellationToken cancellation);
    }
}
