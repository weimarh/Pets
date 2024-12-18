using ErrorOr;
using MediatR;

namespace Application.Pets.Delete;

public record DeletePetCommand(Guid Id)  : IRequest<ErrorOr<Unit>>;