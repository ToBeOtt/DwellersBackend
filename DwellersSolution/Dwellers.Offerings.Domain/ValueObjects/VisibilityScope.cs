using SharedKernel.Domain.DomainModels;

namespace Dwellers.Offerings.Domain.ValueObjects
{
    public enum VisibilityScope
    {
        Household,
        Neightbourhood,
        All
    }

    public class Visibility : ValueObject
    {
        public VisibilityScope Scope { get; }

        public Visibility(VisibilityScope scope)
        {
            Scope = scope;
        }

        public static Visibility FromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(VisibilityScope), dbValue))
            {
                return new Visibility((VisibilityScope)dbValue);
            }
            throw new ArgumentException("Invalid value for VisibilityScope");
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Scope;
        }
    }
}
