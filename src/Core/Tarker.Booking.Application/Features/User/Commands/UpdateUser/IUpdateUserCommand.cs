namespace Tarker.Booking.Application.Features.User.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> Execute(UpdateUserModel model);
    }
}