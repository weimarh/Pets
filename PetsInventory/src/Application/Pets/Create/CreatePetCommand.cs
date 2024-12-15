using ErrorOr;
using MediatR;

namespace Application.Pets.Create;

public record CreatePetCommand(
    string Name,
    int Species,
    string Breed,
    string Color,
    int Sex,
    int IsSterilized,
    string BirthDate,
    string DeathDate
) : IRequest<ErrorOr<Unit>>;