namespace Tarker.Booking.Application.Features.User.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task<bool> Execute(int userId);
    }
}