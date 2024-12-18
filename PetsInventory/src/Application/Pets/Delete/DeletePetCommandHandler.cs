using Domain.Pets;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Pets.Delete;

public sealed class DeletePetCommandHandler : 
    IRequestHandler<DeletePetCommand, ErrorOr<Unit>>
{
    private readonly IPetRepository _petRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePetCommandHandler(IPetRepository petRepository, IUnitOfWork unitOfWork)
    {
        _petRepository = petRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(
        DeletePetCommand request,
        CancellationToken cancellationToken)
    {
        if (await _petRepository.GetByIdAsync(new PetId(request.Id)) is not Pet pet)
        {
            return Error.NotFound("Pet.NotFound", "The pet with the provide Id was not found.");
        }

        _petRepository.Remove(pet);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
