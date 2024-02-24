namespace Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}