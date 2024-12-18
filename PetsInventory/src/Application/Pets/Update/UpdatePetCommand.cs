using Domain.Enums;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Pets.Update;

public record UpdatePetCommand(
    Guid Id,
    string Name,
    Species Species,
    string Breed,
    string Color,
    Sex Sex,
    bool IsSterilized,
    Year BirthDate,
    Year DeathDate
) : IRequest<ErrorOr<Unit>>;