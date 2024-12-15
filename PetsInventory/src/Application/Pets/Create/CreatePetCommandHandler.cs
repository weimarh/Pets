using Domain.Enums;
using Domain.Pets;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Pets.Create;

public sealed class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, ErrorOr<Unit>>
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePetCommandHandler(IUnitOfWork unitOfWork, IPetRepository petRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
    }

    public async Task<ErrorOr<Unit>> Handle(CreatePetCommand command, CancellationToken cancellationToken)
    {
        
        if (Year.Create(command.BirthDate) is not Year birthDate)
        {
            return Error.Validation("Pet.Birthdate", "Year is not a valid format");
        }

        if (Year.Create(command.DeathDate) is not Year deathDate)
        {
            return Error.Validation("Pet.Deathdate", "Year is not a valid format");
        }

        var pet = new Pet(
            new PetId(Guid.NewGuid()),
            command.Name,
            (Species)command.Species,
            command.Breed,
            command.Color,
            (Sex)command.Sex,
            Convert.ToBoolean(command.IsSterilized),
            birthDate,
            deathDate
        );
        
        _petRepository.Add(pet);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
