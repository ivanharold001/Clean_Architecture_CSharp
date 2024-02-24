namespace Tarker.Booking.Application.Features.User.Queries.GetAllUser
{
    public interface IGetAllUserQueries
    {
        Task<List<GetAllUserModel>> Execute();
    }
}