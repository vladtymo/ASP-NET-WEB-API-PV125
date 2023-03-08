using Core.Dtos;
using FluentValidation;

namespace Core.Validators
{
    public class MovieValidators : AbstractValidator<MovieDto>
    {
        public MovieValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Year)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Year can not be bigger than current");
        }
    }
}
