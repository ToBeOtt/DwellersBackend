using SharedKernel.Domain.DomainModels;

namespace Dwellers.Notes.Domain.ValueObjects
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public class NotePriority : ValueObject
    {
        public Priority Priority { get; }

        public NotePriority(Priority priorioty)
        {
            Priority = priorioty;
        }

        public static NotePriority FromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Priority), dbValue))
            {
                return new NotePriority((Priority)dbValue);
            }
            throw new ArgumentException("Invalid value for priority");
        }

    }
}
