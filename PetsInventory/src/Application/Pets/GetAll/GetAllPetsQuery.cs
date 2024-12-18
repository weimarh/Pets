using Application.Pets.Common;
using ErrorOr;
using MediatR;

namespace Application.Pets.GetAll;

public record GetAllPetsQuery() : IRequest<ErrorOr<IReadOnlyList<PetResponse>>>;