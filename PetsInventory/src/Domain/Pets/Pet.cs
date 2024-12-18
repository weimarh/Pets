using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Pets;

public sealed class Pet : AggregateRoot
{
    public Pet(
        PetId id,
        string name,
        Species species,
        string breed,
        string color,
        Sex sex,
        bool isSterilized,
        Year birthDate,
        Year? deathDate)
    {
        Id = id;
        Name = name;
        Species = species;
        Breed = breed;
        Color = color;
        Sex = sex;
        IsSterilized = isSterilized;
        BirthDate = birthDate;
        DeathDate = deathDate;
    }

    private Pet()
    {
    }

    public PetId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public Species Species { get; private set; }
    public string Breed { get; private set; } = "Criollo";
    public string Color { get; private set; } = string.Empty;
    public Sex Sex { get; private set; }
    public bool IsSterilized { get; private set; }
    public Year BirthDate { get; private set; } = null!;
    public Year? DeathDate { get; private set; }

    public static Pet UpdatePet(
        Guid Id,
        string Name,
        Species Species,
        string Breed,
        string Color,
        Sex Sex,
        bool IsSterilized,
        Year BirthDate,
        Year? DeathDate
    )
    {
        return new Pet(
            new PetId(Id),
            Name,
            Species,
            Breed,
            Color,
            Sex,
            IsSterilized,
            BirthDate,
            DeathDate
        );
    }
}
