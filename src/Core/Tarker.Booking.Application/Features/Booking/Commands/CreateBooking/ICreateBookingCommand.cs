namespace Tarker.Booking.Application.Features.Booking.Commands.CreateBooking
{
    public interface ICreateBookingCommand
    {
        Task<CreateBookingModel> Execute(CreateBookingModel model);
    }
}