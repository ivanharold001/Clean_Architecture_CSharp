namespace Tarker.Booking.Application.Features.User.Queries.GetUserById
{
    public interface IGetUserByIdQueries
    {
        Task<GetUserByIdModel> Execute(int userId);
    }
}