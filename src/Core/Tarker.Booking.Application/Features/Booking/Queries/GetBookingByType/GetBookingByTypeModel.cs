using Tarker.Booking.Domain.Enums;

namespace Tarker.Booking.Application.Features.Booking.Queries.GetBookingByType
{
    public class GetBookingByTypeModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}