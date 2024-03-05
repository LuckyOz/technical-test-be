using Apps.Models.Request;
using FluentValidation;

namespace Apps.Models.Validation
{
    public class PutCrudRequestValidator : AbstractValidator<PutCrudRequest>
    {
        public PutCrudRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id is null or Empty !!");

            RuleFor(x => x.Nama)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is null or Empty !!");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("Status is null or Empty !!");
        }
    }
}
