namespace SharedKernel.Application.ServiceResponse
{
    public class EmptySuccessfulCommandResponse
    {
        // Meant as empty response, similar to MediatR "unit".
        public record DwellerUnit ();
    }
}
