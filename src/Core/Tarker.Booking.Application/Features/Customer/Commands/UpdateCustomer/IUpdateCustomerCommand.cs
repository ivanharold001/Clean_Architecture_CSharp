namespace Tarker.Booking.Application.Features.Customer.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);
    }
}