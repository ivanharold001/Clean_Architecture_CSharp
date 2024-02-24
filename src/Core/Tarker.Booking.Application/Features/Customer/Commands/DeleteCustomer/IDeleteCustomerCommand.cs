namespace Tarker.Booking.Application.Features.Customer.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task<bool> Execute(int customerId);
    }
}