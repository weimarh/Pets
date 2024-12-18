using Domain.Pets;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Pets.Update;

public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, ErrorOr<Unit>>
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePetCommandHandler(IPetRepository petRepository, IUnitOfWork unitOfWork)
    {
        _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));; 
    }

    public async Task<ErrorOr<Unit>> Handle(
        UpdatePetCommand request,
        CancellationToken cancellationToken)
    {
        if (!await _petRepository.ExistsAsync(new PetId(request.Id)))
        {
            return Error.NotFound("Pet.NotFound", "The pet with the provide Id was not found.");
        }

        Pet pet = Pet.UpdatePet(
            request.Id,
            request.Name,
            request.Species,
            request.Breed,
            request.Color,
            request.Sex,
            request.IsSterilized,
            request.BirthDate,
            request.DeathDate);
        
        _petRepository.Update(pet);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
