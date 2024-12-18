using System;
using FluentValidation;

namespace Application.Pets.Delete;

public class DeletePetCommandValidator : AbstractValidator<DeletePetCommand>
{
    public DeletePetCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}
