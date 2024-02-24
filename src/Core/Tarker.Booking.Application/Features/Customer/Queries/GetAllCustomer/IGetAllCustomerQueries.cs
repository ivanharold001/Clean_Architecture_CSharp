namespace Tarker.Booking.Application.Features.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQueries
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}