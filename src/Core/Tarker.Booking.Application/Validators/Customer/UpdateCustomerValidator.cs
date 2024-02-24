using FluentValidation;
using Tarker.Booking.Application.Features.Customer.Commands.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().MaximumLength(8);
        }
    }
}