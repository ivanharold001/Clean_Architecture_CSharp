namespace Tarker.Booking.Application.Features.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerDocumentNumberModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
    }
}