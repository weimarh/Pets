using Application.Pets.Common;
using ErrorOr;
using MediatR;

namespace Application.Pets.GetById;

public record GetPetByIdQuery(Guid Id) : IRequest<ErrorOr<PetResponse>>;
