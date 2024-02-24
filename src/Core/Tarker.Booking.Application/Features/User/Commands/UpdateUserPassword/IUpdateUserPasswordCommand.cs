namespace Tarker.Booking.Application.Features.User.Commands.UpdateUserPassword
{
    public interface IUpdateUserPasswordCommand
    {
        Task<bool> Execute(UpdateUserPasswordModel model);
    }
}