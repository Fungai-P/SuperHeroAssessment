using FluentValidation;
using SuperHeroAssessment.Api.Contracts.Requests;

namespace SuperHeroAssessment.Api.Validation
{
    public class UpdateSuperHeroRequestValidator : AbstractValidator<UpdateSuperHeroRequest>
    {
        public UpdateSuperHeroRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
