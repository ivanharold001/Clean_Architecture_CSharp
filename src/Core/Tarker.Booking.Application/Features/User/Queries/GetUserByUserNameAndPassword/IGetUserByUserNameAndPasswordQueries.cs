namespace Tarker.Booking.Application.Features.User.Queries.GetUserByUserNameAndPassword
{
    public interface IGetUserByUserNameAndPasswordQueries
    {
        Task<GetUserByUserNameAndPasswordModel> Execute(string userName, string password);
    }
}