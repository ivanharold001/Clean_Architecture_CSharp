namespace Tarker.Booking.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}