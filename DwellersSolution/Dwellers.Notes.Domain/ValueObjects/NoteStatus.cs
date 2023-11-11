using SharedKernel.Domain.DomainModels;

namespace Dwellers.Notes.Domain.ValueObjects
{
    public enum Status
    {
        Pending,
        Initialized,
        Done
    }
    public class NoteStatus : ValueObject
    {
        public Status Status { get; }

        public NoteStatus(Status status)
        {
            Status = status;
        }

        public static NoteStatus FromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Status), dbValue))
            {
                return new NoteStatus((Status)dbValue);
            }
            throw new ArgumentException("Invalid value for priority");
        }
    }
}
