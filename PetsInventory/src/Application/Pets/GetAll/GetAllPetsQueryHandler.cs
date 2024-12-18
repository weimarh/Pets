using System;
using Application.Pets.Common;
using Domain.Pets;
using ErrorOr;
using MediatR;

namespace Application.Pets.GetAll;

public class GetAllPetsQueryHandler :
    IRequestHandler<GetAllPetsQuery, ErrorOr<IReadOnlyList<PetResponse>>>
{
    private readonly IPetRepository _petRepository;

    public GetAllPetsQueryHandler(IPetRepository petRepository)
    {
        _petRepository = petRepository ?? 
            throw new ArgumentNullException(nameof(petRepository));
    }
    
    public async Task<ErrorOr<IReadOnlyList<PetResponse>>> Handle(
        GetAllPetsQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<Pet> pets = await _petRepository.GetAll();

        return pets.Select(pet => new PetResponse(
            pet.Id.Value,
            pet.Name,
            pet.Species.ToString(),
            pet.Breed,
            pet.Color,
            pet.Sex.ToString(),
            pet.IsSterilized.ToString(),
            pet.BirthDate.Value,
            pet.DeathDate.Value
        )).ToList();

    }
}
