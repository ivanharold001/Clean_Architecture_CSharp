namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByDocumentNumber
{
    public interface IGetBookingByDocumentNumberQueries
    {
        Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber);
    }
}