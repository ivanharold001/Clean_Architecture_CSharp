using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }
}