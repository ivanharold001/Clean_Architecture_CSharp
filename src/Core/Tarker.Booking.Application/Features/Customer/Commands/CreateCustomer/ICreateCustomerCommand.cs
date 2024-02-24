namespace Tarker.Booking.Application.Features.Customer.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        Task<CreateCustomerModel> Execute(CreateCustomerModel model);
    }
}