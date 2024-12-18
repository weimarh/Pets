using ErrorOr;

namespace Domain.DomainErrors;

public static partial class PetErrors
{
    public static class Pet
    {
        public static Error YearWithBadFormat =>
            Error.Validation("Pet.Year", "Year with bad format.");
    }
}
