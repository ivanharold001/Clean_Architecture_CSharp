using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByType
{
    public interface IGetBookingByTypeQueries
    {
        Task<List<GetBookingByTypeModel>> Execute(string bookingType);
    }
}