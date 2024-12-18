using Application.Pets.Common;
using Domain.Pets;
using ErrorOr;
using MediatR;

namespace Application.Pets.GetById;

public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, ErrorOr<PetResponse>>
{
    private readonly IPetRepository _petRepository;

    public GetPetByIdQueryHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository ?? 
            throw new ArgumentNullException(nameof(petRepository));
    }

    public async Task<ErrorOr<PetResponse>> Handle(
        GetPetByIdQuery query,
        CancellationToken cancellationToken)
    {
        if (await _petRepository.GetByIdAsync(new PetId(query.Id)) is not Pet pet)
        {
            return Error.NotFound(description: "Pet not found");
        }

        return new PetResponse(
            pet.Id.Value,
            pet.Name,
            pet.Species.ToString(),
            pet.Breed,
            pet.Color,
            pet.Sex.ToString(),
            pet.IsSterilized.ToString(),
            pet.BirthDate.Value,
            pet.DeathDate.Value
        );
    }
    
}
