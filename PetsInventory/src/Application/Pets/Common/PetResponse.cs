namespace Application.Pets.Common;

public record PetResponse(
    Guid Id,
    string Name,
    string? Species,
    string? Breed,
    string? Color,
    string? Sex,
    string? IsSterilized,
    string? BirthDate,
    string? DeathDate
);