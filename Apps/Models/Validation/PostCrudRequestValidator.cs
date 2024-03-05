
using Apps.Models.Request;
using FluentValidation;

namespace Apps.Models.Validation
{
    public class PostCrudRequestValidator : AbstractValidator<PostCrudRequest>
    {
        public PostCrudRequestValidator()
        {
            RuleFor(x => x.Nama)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is null !!");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("Status is null !!");
        }
    }
}
