namespace SharedKernel.Exceptions.Common
{
    public abstract class DwellersValidationException : DwellersAppException
    {
        public List<string> ValidationMessages { get; set; }
        protected DwellersValidationException(string message, int exceptionCode) : base(message, exceptionCode)
        {
        }
    }
}
