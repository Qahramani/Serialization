using FluentValidation;

namespace Serialization.Validators.PersonDtoValidations;

public class PersonPutDtoValidator : AbstractValidator<PersonPutDto>
{
    public PersonPutDtoValidator()
    {
        RuleFor(x => x.Id).GreaterThan(-1);
        RuleFor(x => x.Firstname).NotEmpty().MinimumLength(2).MaximumLength(256).WithMessage("Uzunluq 2 - 256 arasi olmalidir");
        RuleFor(x => x.Lastname).NotEmpty().MinimumLength(2).MaximumLength(256);
        RuleFor(x => x.Age).NotEmpty().GreaterThan(0).LessThan(120).WithMessage("yas 0 - 120 arasi olmalidir");
    }
}
