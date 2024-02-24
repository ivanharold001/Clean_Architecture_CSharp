using FluentValidation;
using Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidation : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidation()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}