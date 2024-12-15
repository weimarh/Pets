using FluentValidation;

namespace Application.Pets.Create;

public class CreatePetCommandBehavior : AbstractValidator<CreatePetCommand>
{
    public CreatePetCommandBehavior()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.Breed)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Color)
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .MaximumLength(4);
        
        RuleFor(x => x.DeathDate)
            .NotEmpty()
            .MaximumLength(4)
            .WithName("Death Date");
    }
}
