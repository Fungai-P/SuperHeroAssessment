using FluentValidation;
using SuperHeroAssessment.Api.Contracts.Requests;

namespace SuperHeroAssessment.Api.Validation
{
    public class CreateSuperHeroRequestValidator : AbstractValidator<CreateSuperHeroRequest>
    {
        public CreateSuperHeroRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
