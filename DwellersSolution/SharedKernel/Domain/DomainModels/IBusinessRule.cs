namespace SharedKernel.Domain.DomainModels
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}