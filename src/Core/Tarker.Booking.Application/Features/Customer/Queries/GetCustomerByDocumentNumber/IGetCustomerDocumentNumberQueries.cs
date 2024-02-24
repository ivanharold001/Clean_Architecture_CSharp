namespace Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber
{
    public interface IGetCustomerDocumentNumberQueries
    {
        Task<GetCustomerDocumentNumberModel> Execute(string documentNumber);
    }
}