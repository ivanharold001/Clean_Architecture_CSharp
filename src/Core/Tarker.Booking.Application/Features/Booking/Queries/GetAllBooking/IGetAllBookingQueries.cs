namespace Tarker.Booking.Application.Features.Booking.Queries.GetAllBooking
{
    public interface IGetAllBookingQueries
    {
        Task<List<GetAllBookingModel>> Execute();
    }
}