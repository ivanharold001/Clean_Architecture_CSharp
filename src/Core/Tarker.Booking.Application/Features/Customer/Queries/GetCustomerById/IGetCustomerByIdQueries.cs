namespace Tarker.Booking.Application.Features.Customer.Queries.GetCustomerById
{
    public interface IGetCustomerByIdQueries
    {
        Task<GetCustomerByIdModel> Execute(int customerId);
    }
}